using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Conversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateConversationRequest>.WithActionResult<
        CreateConversationResponse>
    {
        private readonly IRepository<InteractionType> _interactionTypeRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Conversation> _repository;

        public Create(
            IRepository<Conversation> repository,
            IRepository<InteractionType> interactionTypeRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _interactionTypeRepository = interactionTypeRepository;
        }

        [HttpPost("api/conversations")]
        [SwaggerOperation(
            Summary = "Creates a new Conversation",
            Description = "Creates a new Conversation",
            OperationId = "conversations.create",
            Tags = new[] { "ConversationEndpoints" })
        ]
        public override async Task<ActionResult<CreateConversationResponse>> HandleAsync(
            CreateConversationRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateConversationResponse(request.CorrelationId());

            //var interactionType = await _interactionTypeRepository.GetByIdAsync(request.InteractionTypeId);// parent entity

            var newConversation = new Conversation(
                Guid.NewGuid(),
                request.InteractionTypeId,
                request.RegionAreaAdvisorCategoryId,
                request.UnansweredConversationId,
                request.ReconnectConversationId,
                request.ConversationSumTimeInSecs,
                request.ConversationSumSpent,
                request.LostSignalCustomer,
                request.LostSignalAdvisor,
                request.CanceledByCustomer,
                request.CanceledByAdvisor,
                request.EndedByNoBalance,
                request.StillActive,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newConversation);

            _logger.LogInformation(
                $"Conversation created  with Id {newConversation.ConversationId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ConversationDto>(newConversation);

            var conversationCreatedEvent = new ConversationCreatedEvent(newConversation, "Mongo-History");
            _messagePublisher.Publish(conversationCreatedEvent);

            response.Conversation = dto;


            return Ok(response);
        }
    }
}