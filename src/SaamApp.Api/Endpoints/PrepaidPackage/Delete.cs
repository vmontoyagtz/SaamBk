using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeletePrepaidPackageRequest>.WithActionResult<
        DeletePrepaidPackageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PrepaidPackage> _prepaidPackageReadRepository;
        private readonly IRepository<PrepaidPackageRedemption> _prepaidPackageRedemptionRepository;
        private readonly IRepository<PrepaidPackage> _repository;
        private readonly IRepository<SerfinsaPayment> _serfinsaPaymentRepository;

        public Delete(IRepository<PrepaidPackage> PrepaidPackageRepository,
            IRepository<PrepaidPackage> PrepaidPackageReadRepository,
            IRepository<PrepaidPackageRedemption> prepaidPackageRedemptionRepository,
            IRepository<SerfinsaPayment> serfinsaPaymentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = PrepaidPackageRepository;
            _prepaidPackageReadRepository = PrepaidPackageReadRepository;
            _prepaidPackageRedemptionRepository = prepaidPackageRedemptionRepository;
            _serfinsaPaymentRepository = serfinsaPaymentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/prepaidPackages/{PrepaidPackageId}")]
        [SwaggerOperation(
            Summary = "Deletes an PrepaidPackage",
            Description = "Deletes an PrepaidPackage",
            OperationId = "prepaidPackages.delete",
            Tags = new[] { "PrepaidPackageEndpoints" })
        ]
        public override async Task<ActionResult<DeletePrepaidPackageResponse>> HandleAsync(
            [FromRoute] DeletePrepaidPackageRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePrepaidPackageResponse(request.CorrelationId());

            var prepaidPackage = await _prepaidPackageReadRepository.GetByIdAsync(request.PrepaidPackageId);

            if (prepaidPackage == null)
            {
                return NotFound();
            }

            var prepaidPackageRedemptionSpec =
                new GetPrepaidPackageRedemptionWithPrepaidPackageKeySpec(prepaidPackage.PrepaidPackageId);
            var prepaidPackageRedemptions =
                await _prepaidPackageRedemptionRepository.ListAsync(prepaidPackageRedemptionSpec);
            await _prepaidPackageRedemptionRepository
                .DeleteRangeAsync(prepaidPackageRedemptions); // you could use soft delete with IsDeleted = true
            var serfinsaPaymentSpec = new GetSerfinsaPaymentWithPrepaidPackageKeySpec(prepaidPackage.PrepaidPackageId);
            var serfinsaPayments = await _serfinsaPaymentRepository.ListAsync(serfinsaPaymentSpec);
            await _serfinsaPaymentRepository
                .DeleteRangeAsync(serfinsaPayments); // you could use soft delete with IsDeleted = true

            var prepaidPackageDeletedEvent = new PrepaidPackageDeletedEvent(prepaidPackage, "Mongo-History");
            _messagePublisher.Publish(prepaidPackageDeletedEvent);

            await _repository.DeleteAsync(prepaidPackage);

            return Ok(response);
        }
    }
}