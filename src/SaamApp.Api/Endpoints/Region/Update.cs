using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Region;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.RegionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateRegionRequest>.WithActionResult<UpdateRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Region> _repository;

        public Update(
            IRepository<Region> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/regions")]
        [SwaggerOperation(
            Summary = "Updates a Region",
            Description = "Updates a Region",
            OperationId = "regions.update",
            Tags = new[] { "RegionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateRegionResponse>> HandleAsync(UpdateRegionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateRegionResponse(request.CorrelationId());

            var regToUpdate = _mapper.Map<Region>(request);

            var regionToUpdateTest = await _repository.GetByIdAsync(request.RegionId);
            if (regionToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(regToUpdate);

            var regionUpdatedEvent = new RegionUpdatedEvent(regToUpdate, "Mongo-History");
            _messagePublisher.Publish(regionUpdatedEvent);

            var dto = _mapper.Map<RegionDto>(regToUpdate);
            response.Region = dto;

            return Ok(response);
        }
    }
}