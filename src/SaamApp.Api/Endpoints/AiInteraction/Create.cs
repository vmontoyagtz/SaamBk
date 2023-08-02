using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiInteraction;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiInteractionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiInteractionRequest>.WithActionResult<
        CreateAiInteractionResponse>
    {
        private readonly IRepository<AiRobot> _aiRobotRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiInteraction> _repository;

        public Create(
            IRepository<AiInteraction> repository,
            IRepository<AiRobot> aiRobotRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _aiRobotRepository = aiRobotRepository;
        }

        [HttpPost("api/aiInteractions")]
        [SwaggerOperation(
            Summary = "Creates a new AiInteraction",
            Description = "Creates a new AiInteraction",
            OperationId = "aiInteractions.create",
            Tags = new[] { "AiInteractionEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiInteractionResponse>> HandleAsync(
            CreateAiInteractionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiInteractionResponse(request.CorrelationId());

            //var aiRobot = await _aiRobotRepository.GetByIdAsync(request.AiRobotId);// parent entity

            var newAiInteraction = new AiInteraction(
                Guid.NewGuid(),
                request.AiRobotId,
                request.CustomerId,
                request.SessionId,
                request.Question,
                request.Answer,
                request.InteractionTime,
                request.IsSuccessful
            );


            await _repository.AddAsync(newAiInteraction);

            _logger.LogInformation(
                $"AiInteraction created  with Id {newAiInteraction.AiInteractionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiInteractionDto>(newAiInteraction);

            var aiInteractionCreatedEvent = new AiInteractionCreatedEvent(newAiInteraction, "Mongo-History");
            _messagePublisher.Publish(aiInteractionCreatedEvent);

            response.AiInteraction = dto;


            return Ok(response);
        }
    }
}