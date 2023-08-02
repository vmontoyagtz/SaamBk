using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackageRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.PrepaidPackageRedemptionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdatePrepaidPackageRedemptionRequest>.WithActionResult<
        UpdatePrepaidPackageRedemptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PrepaidPackageRedemption> _repository;

        public Update(
            IRepository<PrepaidPackageRedemption> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/prepaidPackageRedemptions")]
        [SwaggerOperation(
            Summary = "Updates a PrepaidPackageRedemption",
            Description = "Updates a PrepaidPackageRedemption",
            OperationId = "prepaidPackageRedemptions.update",
            Tags = new[] { "PrepaidPackageRedemptionEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePrepaidPackageRedemptionResponse>> HandleAsync(
            UpdatePrepaidPackageRedemptionRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePrepaidPackageRedemptionResponse(request.CorrelationId());

            var pprrpreprToUpdate = _mapper.Map<PrepaidPackageRedemption>(request);

            var prepaidPackageRedemptionToUpdateTest =
                await _repository.GetByIdAsync(request.PrepaidPackageRedemptionId);
            if (prepaidPackageRedemptionToUpdateTest is null)
            {
                return NotFound();
            }

            pprrpreprToUpdate.UpdateCustomerForPrepaidPackageRedemption(request.CustomerId);
            pprrpreprToUpdate.UpdatePrepaidPackageForPrepaidPackageRedemption(request.PrepaidPackageId);
            await _repository.UpdateAsync(pprrpreprToUpdate);

            var prepaidPackageRedemptionUpdatedEvent =
                new PrepaidPackageRedemptionUpdatedEvent(pprrpreprToUpdate, "Mongo-History");
            _messagePublisher.Publish(prepaidPackageRedemptionUpdatedEvent);

            var dto = _mapper.Map<PrepaidPackageRedemptionDto>(pprrpreprToUpdate);
            response.PrepaidPackageRedemption = dto;

            return Ok(response);
        }
    }
}