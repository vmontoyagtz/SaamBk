using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.GiftCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GiftCodeRedemptionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteGiftCodeRedemptionRequest>.WithActionResult<
        DeleteGiftCodeRedemptionResponse>
    {
        private readonly IRepository<GiftCodeRedemption> _giftCodeRedemptionReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<GiftCodeRedemption> _repository;

        public Delete(IRepository<GiftCodeRedemption> GiftCodeRedemptionRepository,
            IRepository<GiftCodeRedemption> GiftCodeRedemptionReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = GiftCodeRedemptionRepository;
            _giftCodeRedemptionReadRepository = GiftCodeRedemptionReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/giftCodeRedemptions/{GiftCodeRedemptionId}")]
        [SwaggerOperation(
            Summary = "Deletes an GiftCodeRedemption",
            Description = "Deletes an GiftCodeRedemption",
            OperationId = "giftCodeRedemptions.delete",
            Tags = new[] { "GiftCodeRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteGiftCodeRedemptionResponse>> HandleAsync(
            [FromRoute] DeleteGiftCodeRedemptionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteGiftCodeRedemptionResponse(request.CorrelationId());

            var giftCodeRedemption = await _giftCodeRedemptionReadRepository.GetByIdAsync(request.GiftCodeRedemptionId);

            if (giftCodeRedemption == null)
            {
                return NotFound();
            }


            var giftCodeRedemptionDeletedEvent =
                new GiftCodeRedemptionDeletedEvent(giftCodeRedemption, "Mongo-History");
            _messagePublisher.Publish(giftCodeRedemptionDeletedEvent);

            await _repository.DeleteAsync(giftCodeRedemption);

            return Ok(response);
        }
    }
}