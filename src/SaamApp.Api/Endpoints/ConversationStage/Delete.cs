using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationStage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ConversationStageEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteConversationStageRequest>.WithActionResult<
        DeleteConversationStageResponse>
    {
        private readonly IRepository<ConversationStage> _conversationStageReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ConversationStage> _repository;

        public Delete(IRepository<ConversationStage> ConversationStageRepository,
            IRepository<ConversationStage> ConversationStageReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ConversationStageRepository;
            _conversationStageReadRepository = ConversationStageReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/conversationStages/{ConversationStageId}")]
        [SwaggerOperation(
            Summary = "Deletes an ConversationStage",
            Description = "Deletes an ConversationStage",
            OperationId = "conversationStages.delete",
            Tags = new[] { "ConversationStageEndpoints" })
        ]
        public override async Task<ActionResult<DeleteConversationStageResponse>> HandleAsync(
            [FromRoute] DeleteConversationStageRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteConversationStageResponse(request.CorrelationId());

            var conversationStage = await _conversationStageReadRepository.GetByIdAsync(request.ConversationStageId);

            if (conversationStage == null)
            {
                return NotFound();
            }


            var conversationStageDeletedEvent = new ConversationStageDeletedEvent(conversationStage, "Mongo-History");
            _messagePublisher.Publish(conversationStageDeletedEvent);

            await _repository.DeleteAsync(conversationStage);

            return Ok(response);
        }
    }
}