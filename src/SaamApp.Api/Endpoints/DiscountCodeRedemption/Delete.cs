using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeRedemptionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteDiscountCodeRedemptionRequest>.WithActionResult<
        DeleteDiscountCodeRedemptionResponse>
    {
        private readonly IRepository<DiscountCodeRedemption> _discountCodeRedemptionReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DiscountCodeRedemption> _repository;

        public Delete(IRepository<DiscountCodeRedemption> DiscountCodeRedemptionRepository,
            IRepository<DiscountCodeRedemption> DiscountCodeRedemptionReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = DiscountCodeRedemptionRepository;
            _discountCodeRedemptionReadRepository = DiscountCodeRedemptionReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/discountCodeRedemptions/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an DiscountCodeRedemption",
            Description = "Deletes an DiscountCodeRedemption",
            OperationId = "discountCodeRedemptions.delete",
            Tags = new[] { "DiscountCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteDiscountCodeRedemptionResponse>> HandleAsync(
            [FromRoute] DeleteDiscountCodeRedemptionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteDiscountCodeRedemptionResponse(request.CorrelationId());

            var discountCodeRedemption = await _discountCodeRedemptionReadRepository.GetByIdAsync(request.RowId);

            if (discountCodeRedemption == null)
            {
                return NotFound();
            }


            var discountCodeRedemptionDeletedEvent =
                new DiscountCodeRedemptionDeletedEvent(discountCodeRedemption, "Mongo-History");
            _messagePublisher.Publish(discountCodeRedemptionDeletedEvent);

            await _repository.DeleteAsync(discountCodeRedemption);

            return Ok(response);
        }
    }
}