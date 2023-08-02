using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.GiftCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GiftCodeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteGiftCodeRequest>.WithActionResult<
        DeleteGiftCodeResponse>
    {
        private readonly IRepository<GiftCode> _giftCodeReadRepository;
        private readonly IRepository<GiftCodeRedemption> _giftCodeRedemptionRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<GiftCode> _repository;

        public Delete(IRepository<GiftCode> GiftCodeRepository, IRepository<GiftCode> GiftCodeReadRepository,
            IRepository<GiftCodeRedemption> giftCodeRedemptionRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = GiftCodeRepository;
            _giftCodeReadRepository = GiftCodeReadRepository;
            _giftCodeRedemptionRepository = giftCodeRedemptionRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/giftCodes/{GiftCodeId}")]
        [SwaggerOperation(
            Summary = "Deletes an GiftCode",
            Description = "Deletes an GiftCode",
            OperationId = "giftCodes.delete",
            Tags = new[] { "GiftCodeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteGiftCodeResponse>> HandleAsync(
            [FromRoute] DeleteGiftCodeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteGiftCodeResponse(request.CorrelationId());

            var giftCode = await _giftCodeReadRepository.GetByIdAsync(request.GiftCodeId);

            if (giftCode == null)
            {
                return NotFound();
            }

            var giftCodeRedemptionSpec = new GetGiftCodeRedemptionWithGiftCodeKeySpec(giftCode.GiftCodeId);
            var giftCodeRedemptions = await _giftCodeRedemptionRepository.ListAsync(giftCodeRedemptionSpec);
            await _giftCodeRedemptionRepository
                .DeleteRangeAsync(giftCodeRedemptions); // you could use soft delete with IsDeleted = true

            var giftCodeDeletedEvent = new GiftCodeDeletedEvent(giftCode, "Mongo-History");
            _messagePublisher.Publish(giftCodeDeletedEvent);

            await _repository.DeleteAsync(giftCode);

            return Ok(response);
        }
    }
}