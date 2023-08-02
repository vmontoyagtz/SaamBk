using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ConversationStage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ConversationStageEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateConversationStageRequest>.WithActionResult<
        UpdateConversationStageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ConversationStage> _repository;

        public Update(
            IRepository<ConversationStage> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/conversationStages")]
        [SwaggerOperation(
            Summary = "Updates a ConversationStage",
            Description = "Updates a ConversationStage",
            OperationId = "conversationStages.update",
            Tags = new[] { "ConversationStageEndpoints" })
        ]
        public override async Task<ActionResult<UpdateConversationStageResponse>> HandleAsync(
            UpdateConversationStageRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateConversationStageResponse(request.CorrelationId());

            var csosnsToUpdate = _mapper.Map<ConversationStage>(request);

            var conversationStageToUpdateTest = await _repository.GetByIdAsync(request.ConversationStageId);
            if (conversationStageToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(csosnsToUpdate);

            var conversationStageUpdatedEvent = new ConversationStageUpdatedEvent(csosnsToUpdate, "Mongo-History");
            _messagePublisher.Publish(conversationStageUpdatedEvent);

            var dto = _mapper.Map<ConversationStageDto>(csosnsToUpdate);
            response.ConversationStage = dto;

            return Ok(response);
        }
    }
}