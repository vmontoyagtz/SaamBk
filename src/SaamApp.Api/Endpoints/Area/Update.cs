using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Area;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AreaEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAreaRequest>.WithActionResult<UpdateAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Area> _repository;

        public Update(
            IRepository<Area> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/areas")]
        [SwaggerOperation(
            Summary = "Updates a Area",
            Description = "Updates a Area",
            OperationId = "areas.update",
            Tags = new[] { "AreaEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAreaResponse>> HandleAsync(UpdateAreaRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAreaResponse(request.CorrelationId());

            var areToUpdate = _mapper.Map<Area>(request);

            var areaToUpdateTest = await _repository.GetByIdAsync(request.AreaId);
            if (areaToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(areToUpdate);

            var areaUpdatedEvent = new AreaUpdatedEvent(areToUpdate, "Mongo-History");
            _messagePublisher.Publish(areaUpdatedEvent);

            var dto = _mapper.Map<AreaDto>(areToUpdate);
            response.Area = dto;

            return Ok(response);
        }
    }
}