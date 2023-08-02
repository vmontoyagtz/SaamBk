using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.GiftCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.GiftCodeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateGiftCodeRequest>.WithActionResult<UpdateGiftCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<GiftCode> _repository;

        public Update(
            IRepository<GiftCode> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/giftCodes")]
        [SwaggerOperation(
            Summary = "Updates a GiftCode",
            Description = "Updates a GiftCode",
            OperationId = "giftCodes.update",
            Tags = new[] { "GiftCodeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateGiftCodeResponse>> HandleAsync(UpdateGiftCodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateGiftCodeResponse(request.CorrelationId());

            var gcicfcToUpdate = _mapper.Map<GiftCode>(request);

            var giftCodeToUpdateTest = await _repository.GetByIdAsync(request.GiftCodeId);
            if (giftCodeToUpdateTest is null)
            {
                return NotFound();
            }

            gcicfcToUpdate.UpdateRegionForGiftCode(request.RegionId);
            await _repository.UpdateAsync(gcicfcToUpdate);

            var giftCodeUpdatedEvent = new GiftCodeUpdatedEvent(gcicfcToUpdate, "Mongo-History");
            _messagePublisher.Publish(giftCodeUpdatedEvent);

            var dto = _mapper.Map<GiftCodeDto>(gcicfcToUpdate);
            response.GiftCode = dto;

            return Ok(response);
        }
    }
}