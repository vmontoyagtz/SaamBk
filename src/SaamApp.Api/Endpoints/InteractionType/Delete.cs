using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InteractionType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InteractionTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteInteractionTypeRequest>.WithActionResult<
        DeleteInteractionTypeResponse>
    {
        private readonly IRepository<Conversation> _conversationRepository;
        private readonly IRepository<InteractionType> _interactionTypeReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<InteractionType> _repository;
        private readonly IRepository<UnansweredConversation> _unansweredConversationRepository;

        public Delete(IRepository<InteractionType> InteractionTypeRepository,
            IRepository<InteractionType> InteractionTypeReadRepository,
            IRepository<Conversation> conversationRepository,
            IRepository<Message> messageRepository,
            IRepository<UnansweredConversation> unansweredConversationRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = InteractionTypeRepository;
            _interactionTypeReadRepository = InteractionTypeReadRepository;
            _conversationRepository = conversationRepository;
            _messageRepository = messageRepository;
            _unansweredConversationRepository = unansweredConversationRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/interactionTypes/{InteractionTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an InteractionType",
            Description = "Deletes an InteractionType",
            OperationId = "interactionTypes.delete",
            Tags = new[] { "InteractionTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteInteractionTypeResponse>> HandleAsync(
            [FromRoute] DeleteInteractionTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteInteractionTypeResponse(request.CorrelationId());

            var interactionType = await _interactionTypeReadRepository.GetByIdAsync(request.InteractionTypeId);

            if (interactionType == null)
            {
                return NotFound();
            }

            var conversationSpec = new GetConversationWithInteractionTypeKeySpec(interactionType.InteractionTypeId);
            var conversations = await _conversationRepository.ListAsync(conversationSpec);
            await _conversationRepository
                .DeleteRangeAsync(conversations); // you could use soft delete with IsDeleted = true
            var messageSpec = new GetMessageWithInteractionTypeKeySpec(interactionType.InteractionTypeId);
            var messages = await _messageRepository.ListAsync(messageSpec);
            await _messageRepository.DeleteRangeAsync(messages); // you could use soft delete with IsDeleted = true
            var unansweredConversationSpec =
                new GetUnansweredConversationWithInteractionTypeKeySpec(interactionType.InteractionTypeId);
            var unansweredConversations = await _unansweredConversationRepository.ListAsync(unansweredConversationSpec);
            await _unansweredConversationRepository
                .DeleteRangeAsync(unansweredConversations); // you could use soft delete with IsDeleted = true

            var interactionTypeDeletedEvent = new InteractionTypeDeletedEvent(interactionType, "Mongo-History");
            _messagePublisher.Publish(interactionTypeDeletedEvent);

            await _repository.DeleteAsync(interactionType);

            return Ok(response);
        }
    }
}