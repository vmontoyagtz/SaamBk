using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobot;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiRobotEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiRobotRequest>.WithActionResult<UpdateAiRobotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiRobot> _repository;

        public Update(
            IRepository<AiRobot> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiRobots")]
        [SwaggerOperation(
            Summary = "Updates a AiRobot",
            Description = "Updates a AiRobot",
            OperationId = "aiRobots.update",
            Tags = new[] { "AiRobotEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiRobotResponse>> HandleAsync(UpdateAiRobotRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAiRobotResponse(request.CorrelationId());

            var arirrToUpdate = _mapper.Map<AiRobot>(request);

            var aiRobotToUpdateTest = await _repository.GetByIdAsync(request.AiRobotId);
            if (aiRobotToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(arirrToUpdate);

            var aiRobotUpdatedEvent = new AiRobotUpdatedEvent(arirrToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiRobotUpdatedEvent);

            var dto = _mapper.Map<AiRobotDto>(arirrToUpdate);
            response.AiRobot = dto;

            return Ok(response);
        }
    }
}