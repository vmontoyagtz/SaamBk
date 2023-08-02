using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteDiscountCodeRequest>.WithActionResult<
        DeleteDiscountCodeResponse>
    {
        private readonly IRepository<DiscountCode> _discountCodeReadRepository;
        private readonly IRepository<DiscountCodeRedemption> _discountCodeRedemptionRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DiscountCode> _repository;
        private readonly IRepository<SerfinsaPayment> _serfinsaPaymentRepository;

        public Delete(IRepository<DiscountCode> DiscountCodeRepository,
            IRepository<DiscountCode> DiscountCodeReadRepository,
            IRepository<DiscountCodeRedemption> discountCodeRedemptionRepository,
            IRepository<SerfinsaPayment> serfinsaPaymentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = DiscountCodeRepository;
            _discountCodeReadRepository = DiscountCodeReadRepository;
            _discountCodeRedemptionRepository = discountCodeRedemptionRepository;
            _serfinsaPaymentRepository = serfinsaPaymentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/discountCodes/{DiscountCodeId}")]
        [SwaggerOperation(
            Summary = "Deletes an DiscountCode",
            Description = "Deletes an DiscountCode",
            OperationId = "discountCodes.delete",
            Tags = new[] { "DiscountCodeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteDiscountCodeResponse>> HandleAsync(
            [FromRoute] DeleteDiscountCodeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteDiscountCodeResponse(request.CorrelationId());

            var discountCode = await _discountCodeReadRepository.GetByIdAsync(request.DiscountCodeId);

            if (discountCode == null)
            {
                return NotFound();
            }

            var discountCodeRedemptionSpec =
                new GetDiscountCodeRedemptionWithDiscountCodeKeySpec(discountCode.DiscountCodeId);
            var discountCodeRedemptions = await _discountCodeRedemptionRepository.ListAsync(discountCodeRedemptionSpec);
            await _discountCodeRedemptionRepository.DeleteRangeAsync(discountCodeRedemptions);
            var serfinsaPaymentSpec = new GetSerfinsaPaymentWithDiscountCodeKeySpec(discountCode.DiscountCodeId);
            var serfinsaPayments = await _serfinsaPaymentRepository.ListAsync(serfinsaPaymentSpec);
            await _serfinsaPaymentRepository
                .DeleteRangeAsync(serfinsaPayments); // you could use soft delete with IsDeleted = true

            var discountCodeDeletedEvent = new DiscountCodeDeletedEvent(discountCode, "Mongo-History");
            _messagePublisher.Publish(discountCodeDeletedEvent);

            await _repository.DeleteAsync(discountCode);

            return Ok(response);
        }
    }
}