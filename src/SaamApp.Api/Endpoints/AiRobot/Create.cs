using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiRobot;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiRobotRequest>.WithActionResult<
        CreateAiRobotResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiRobot> _repository;

        public Create(
            IRepository<AiRobot> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/aiRobots")]
        [SwaggerOperation(
            Summary = "Creates a new AiRobot",
            Description = "Creates a new AiRobot",
            OperationId = "aiRobots.create",
            Tags = new[] { "AiRobotEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiRobotResponse>> HandleAsync(
            CreateAiRobotRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiRobotResponse(request.CorrelationId());


            var newAiRobot = new AiRobot(
                Guid.NewGuid(),
                request.AiRobotName,
                request.AiRobotDescription,
                request.AiRobotUnitPrice,
                request.AiRobotIsActive,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newAiRobot);

            _logger.LogInformation(
                $"AiRobot created  with Id {newAiRobot.AiRobotId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiRobotDto>(newAiRobot);

            var aiRobotCreatedEvent = new AiRobotCreatedEvent(newAiRobot, "Mongo-History");
            _messagePublisher.Publish(aiRobotCreatedEvent);

            response.AiRobot = dto;


            return Ok(response);
        }
    }
}