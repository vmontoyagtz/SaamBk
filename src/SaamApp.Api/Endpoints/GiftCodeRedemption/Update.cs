using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.GiftCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.GiftCodeRedemptionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateGiftCodeRedemptionRequest>.WithActionResult<
        UpdateGiftCodeRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<GiftCodeRedemption> _repository;

        public Update(
            IRepository<GiftCodeRedemption> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/giftCodeRedemptions")]
        [SwaggerOperation(
            Summary = "Updates a GiftCodeRedemption",
            Description = "Updates a GiftCodeRedemption",
            OperationId = "giftCodeRedemptions.update",
            Tags = new[] { "GiftCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateGiftCodeRedemptionResponse>> HandleAsync(
            UpdateGiftCodeRedemptionRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateGiftCodeRedemptionResponse(request.CorrelationId());

            var gcricrfcrToUpdate = _mapper.Map<GiftCodeRedemption>(request);

            var giftCodeRedemptionToUpdateTest = await _repository.GetByIdAsync(request.GiftCodeRedemptionId);
            if (giftCodeRedemptionToUpdateTest is null)
            {
                return NotFound();
            }

            gcricrfcrToUpdate.UpdateCustomerForGiftCodeRedemption(request.CustomerId);
            gcricrfcrToUpdate.UpdateGiftCodeForGiftCodeRedemption(request.GiftCodeId);
            await _repository.UpdateAsync(gcricrfcrToUpdate);

            var giftCodeRedemptionUpdatedEvent = new GiftCodeRedemptionUpdatedEvent(gcricrfcrToUpdate, "Mongo-History");
            _messagePublisher.Publish(giftCodeRedemptionUpdatedEvent);

            var dto = _mapper.Map<GiftCodeRedemptionDto>(gcricrfcrToUpdate);
            response.GiftCodeRedemption = dto;

            return Ok(response);
        }
    }
}