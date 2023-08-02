using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UnansweredConversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UnansweredConversationEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteUnansweredConversationRequest>.WithActionResult<
        DeleteUnansweredConversationResponse>
    {
        private readonly IRepository<Conversation> _conversationRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<UnansweredConversation> _repository;
        private readonly IRepository<UnansweredConversation> _unansweredConversationReadRepository;

        public Delete(IRepository<UnansweredConversation> UnansweredConversationRepository,
            IRepository<UnansweredConversation> UnansweredConversationReadRepository,
            IRepository<Conversation> conversationRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = UnansweredConversationRepository;
            _unansweredConversationReadRepository = UnansweredConversationReadRepository;
            _conversationRepository = conversationRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/unansweredConversations/{UnansweredConversationId}")]
        [SwaggerOperation(
            Summary = "Deletes an UnansweredConversation",
            Description = "Deletes an UnansweredConversation",
            OperationId = "unansweredConversations.delete",
            Tags = new[] { "UnansweredConversationEndpoints" })
        ]
        public override async Task<ActionResult<DeleteUnansweredConversationResponse>> HandleAsync(
            [FromRoute] DeleteUnansweredConversationRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteUnansweredConversationResponse(request.CorrelationId());

            var unansweredConversation =
                await _unansweredConversationReadRepository.GetByIdAsync(request.UnansweredConversationId);

            if (unansweredConversation == null)
            {
                return NotFound();
            }

            var conversationSpec =
                new GetConversationWithUnansweredConversationKeySpec(unansweredConversation.UnansweredConversationId);
            var conversations = await _conversationRepository.ListAsync(conversationSpec);
            await _conversationRepository
                .DeleteRangeAsync(conversations); // you could use soft delete with IsDeleted = true

            var unansweredConversationDeletedEvent =
                new UnansweredConversationDeletedEvent(unansweredConversation, "Mongo-History");
            _messagePublisher.Publish(unansweredConversationDeletedEvent);

            await _repository.DeleteAsync(unansweredConversation);

            return Ok(response);
        }
    }
}