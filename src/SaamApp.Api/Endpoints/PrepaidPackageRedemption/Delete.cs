using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PrepaidPackageRedemptionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeletePrepaidPackageRedemptionRequest>.WithActionResult<
        DeletePrepaidPackageRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PrepaidPackageRedemption> _prepaidPackageRedemptionReadRepository;
        private readonly IRepository<PrepaidPackageRedemption> _repository;

        public Delete(IRepository<PrepaidPackageRedemption> PrepaidPackageRedemptionRepository,
            IRepository<PrepaidPackageRedemption> PrepaidPackageRedemptionReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = PrepaidPackageRedemptionRepository;
            _prepaidPackageRedemptionReadRepository = PrepaidPackageRedemptionReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/prepaidPackageRedemptions/{PrepaidPackageRedemptionId}")]
        [SwaggerOperation(
            Summary = "Deletes an PrepaidPackageRedemption",
            Description = "Deletes an PrepaidPackageRedemption",
            OperationId = "prepaidPackageRedemptions.delete",
            Tags = new[] { "PrepaidPackageRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<DeletePrepaidPackageRedemptionResponse>> HandleAsync(
            [FromRoute] DeletePrepaidPackageRedemptionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePrepaidPackageRedemptionResponse(request.CorrelationId());

            var prepaidPackageRedemption =
                await _prepaidPackageRedemptionReadRepository.GetByIdAsync(request.PrepaidPackageRedemptionId);

            if (prepaidPackageRedemption == null)
            {
                return NotFound();
            }


            var prepaidPackageRedemptionDeletedEvent =
                new PrepaidPackageRedemptionDeletedEvent(prepaidPackageRedemption, "Mongo-History");
            _messagePublisher.Publish(prepaidPackageRedemptionDeletedEvent);

            await _repository.DeleteAsync(prepaidPackageRedemption);

            return Ok(response);
        }
    }
}