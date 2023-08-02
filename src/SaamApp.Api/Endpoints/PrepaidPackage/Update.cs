using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PrepaidPackage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.PrepaidPackageEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdatePrepaidPackageRequest>.WithActionResult<
        UpdatePrepaidPackageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PrepaidPackage> _repository;

        public Update(
            IRepository<PrepaidPackage> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/prepaidPackages")]
        [SwaggerOperation(
            Summary = "Updates a PrepaidPackage",
            Description = "Updates a PrepaidPackage",
            OperationId = "prepaidPackages.update",
            Tags = new[] { "PrepaidPackageEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePrepaidPackageResponse>> HandleAsync(
            UpdatePrepaidPackageRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePrepaidPackageResponse(request.CorrelationId());

            var pprpepToUpdate = _mapper.Map<PrepaidPackage>(request);

            var prepaidPackageToUpdateTest = await _repository.GetByIdAsync(request.PrepaidPackageId);
            if (prepaidPackageToUpdateTest is null)
            {
                return NotFound();
            }

            pprpepToUpdate.UpdateRegionForPrepaidPackage(request.RegionId);
            await _repository.UpdateAsync(pprpepToUpdate);

            var prepaidPackageUpdatedEvent = new PrepaidPackageUpdatedEvent(pprpepToUpdate, "Mongo-History");
            _messagePublisher.Publish(prepaidPackageUpdatedEvent);

            var dto = _mapper.Map<PrepaidPackageDto>(pprpepToUpdate);
            response.PrepaidPackage = dto;

            return Ok(response);
        }
    }
}