using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.ConversationStage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationStageEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateConversationStageRequest>.WithActionResult<
        CreateConversationStageResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ConversationStage> _repository;

        public Create(
            IRepository<ConversationStage> repository,
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

        [HttpPost("api/conversationStages")]
        [SwaggerOperation(
            Summary = "Creates a new ConversationStage",
            Description = "Creates a new ConversationStage",
            OperationId = "conversationStages.create",
            Tags = new[] { "ConversationStageEndpoints" })
        ]
        public override async Task<ActionResult<CreateConversationStageResponse>> HandleAsync(
            CreateConversationStageRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateConversationStageResponse(request.CorrelationId());


            var newConversationStage = new ConversationStage(
                Guid.NewGuid(),
                request.ConversationStageName,
                request.ConversationDescription,
                request.TenantId
            );


            await _repository.AddAsync(newConversationStage);

            _logger.LogInformation(
                $"ConversationStage created  with Id {newConversationStage.ConversationStageId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ConversationStageDto>(newConversationStage);

            var conversationStageCreatedEvent =
                new ConversationStageCreatedEvent(newConversationStage, "Mongo-History");
            _messagePublisher.Publish(conversationStageCreatedEvent);

            response.ConversationStage = dto;


            return Ok(response);
        }
    }
}