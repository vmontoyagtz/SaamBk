using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.DiscountCodeRedemptionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateDiscountCodeRedemptionRequest>.WithActionResult<
        UpdateDiscountCodeRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DiscountCodeRedemption> _repository;

        public Update(
            IRepository<DiscountCodeRedemption> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/discountCodeRedemptions")]
        [SwaggerOperation(
            Summary = "Updates a DiscountCodeRedemption",
            Description = "Updates a DiscountCodeRedemption",
            OperationId = "discountCodeRedemptions.update",
            Tags = new[] { "DiscountCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateDiscountCodeRedemptionResponse>> HandleAsync(
            UpdateDiscountCodeRedemptionRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateDiscountCodeRedemptionResponse(request.CorrelationId());

            var dcricrscrToUpdate = _mapper.Map<DiscountCodeRedemption>(request);

            var discountCodeRedemptionToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (discountCodeRedemptionToUpdateTest is null)
            {
                return NotFound();
            }

            dcricrscrToUpdate.UpdateCustomerForDiscountCodeRedemption(request.CustomerId);
            dcricrscrToUpdate.UpdateDiscountCodeForDiscountCodeRedemption(request.DiscountCodeId);
            await _repository.UpdateAsync(dcricrscrToUpdate);

            var discountCodeRedemptionUpdatedEvent =
                new DiscountCodeRedemptionUpdatedEvent(dcricrscrToUpdate, "Mongo-History");
            _messagePublisher.Publish(discountCodeRedemptionUpdatedEvent);

            var dto = _mapper.Map<DiscountCodeRedemptionDto>(dcricrscrToUpdate);
            response.DiscountCodeRedemption = dto;

            return Ok(response);
        }
    }
}