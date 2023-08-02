using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Conversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ConversationEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateConversationRequest>.WithActionResult<
        UpdateConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Conversation> _repository;

        public Update(
            IRepository<Conversation> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/conversations")]
        [SwaggerOperation(
            Summary = "Updates a Conversation",
            Description = "Updates a Conversation",
            OperationId = "conversations.update",
            Tags = new[] { "ConversationEndpoints" })
        ]
        public override async Task<ActionResult<UpdateConversationResponse>> HandleAsync(
            UpdateConversationRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateConversationResponse(request.CorrelationId());

            var conToUpdate = _mapper.Map<Conversation>(request);

            var conversationToUpdateTest = await _repository.GetByIdAsync(request.ConversationId);
            if (conversationToUpdateTest is null)
            {
                return NotFound();
            }

            conToUpdate.UpdateRegionAreaAdvisorCategoryForConversation(request.RegionAreaAdvisorCategoryId);
            conToUpdate.UpdateInteractionTypeForConversation(request.InteractionTypeId);
            conToUpdate.UpdateUnansweredConversationForConversation(request.UnansweredConversationId);
            await _repository.UpdateAsync(conToUpdate);

            var conversationUpdatedEvent = new ConversationUpdatedEvent(conToUpdate, "Mongo-History");
            _messagePublisher.Publish(conversationUpdatedEvent);

            var dto = _mapper.Map<ConversationDto>(conToUpdate);
            response.Conversation = dto;

            return Ok(response);
        }
    }
}