using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Conversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteConversationRequest>.WithActionResult<
        DeleteConversationResponse>
    {
        private readonly IRepository<AdvisorRating> _advisorRatingRepository;
        private readonly IRepository<ConversationPayment> _conversationPaymentRepository;
        private readonly IRepository<Conversation> _conversationReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<Conversation> _repository;

        public Delete(IRepository<Conversation> ConversationRepository,
            IRepository<Conversation> ConversationReadRepository,
            IRepository<AdvisorRating> advisorRatingRepository,
            IRepository<ConversationPayment> conversationPaymentRepository,
            IRepository<Message> messageRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ConversationRepository;
            _conversationReadRepository = ConversationReadRepository;
            _advisorRatingRepository = advisorRatingRepository;
            _conversationPaymentRepository = conversationPaymentRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/conversations/{ConversationId}")]
        [SwaggerOperation(
            Summary = "Deletes an Conversation",
            Description = "Deletes an Conversation",
            OperationId = "conversations.delete",
            Tags = new[] { "ConversationEndpoints" })
        ]
        public override async Task<ActionResult<DeleteConversationResponse>> HandleAsync(
            [FromRoute] DeleteConversationRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteConversationResponse(request.CorrelationId());

            var conversation = await _conversationReadRepository.GetByIdAsync(request.ConversationId);

            if (conversation == null)
            {
                return NotFound();
            }

            var advisorRatingSpec = new GetAdvisorRatingWithConversationKeySpec(conversation.ConversationId);
            var advisorRatings = await _advisorRatingRepository.ListAsync(advisorRatingSpec);
            await _advisorRatingRepository.DeleteRangeAsync(advisorRatings);
            var conversationPaymentSpec =
                new GetConversationPaymentWithConversationKeySpec(conversation.ConversationId);
            var conversationPayments = await _conversationPaymentRepository.ListAsync(conversationPaymentSpec);
            await _conversationPaymentRepository.DeleteRangeAsync(conversationPayments);
            var messageSpec = new GetMessageWithConversationKeySpec(conversation.ConversationId);
            var messages = await _messageRepository.ListAsync(messageSpec);
            await _messageRepository.DeleteRangeAsync(messages); // you could use soft delete with IsDeleted = true

            var conversationDeletedEvent = new ConversationDeletedEvent(conversation, "Mongo-History");
            _messagePublisher.Publish(conversationDeletedEvent);

            await _repository.DeleteAsync(conversation);

            return Ok(response);
        }
    }
}