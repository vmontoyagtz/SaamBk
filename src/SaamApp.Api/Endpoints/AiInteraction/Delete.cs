using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiInteraction;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiInteractionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiInteractionRequest>.WithActionResult<
        DeleteAiInteractionResponse>
    {
        private readonly IRepository<AiInteraction> _aiInteractionReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiInteraction> _repository;

        public Delete(IRepository<AiInteraction> AiInteractionRepository,
            IRepository<AiInteraction> AiInteractionReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiInteractionRepository;
            _aiInteractionReadRepository = AiInteractionReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiInteractions/{AiInteractionId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiInteraction",
            Description = "Deletes an AiInteraction",
            OperationId = "aiInteractions.delete",
            Tags = new[] { "AiInteractionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiInteractionResponse>> HandleAsync(
            [FromRoute] DeleteAiInteractionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiInteractionResponse(request.CorrelationId());

            var aiInteraction = await _aiInteractionReadRepository.GetByIdAsync(request.AiInteractionId);

            if (aiInteraction == null)
            {
                return NotFound();
            }


            var aiInteractionDeletedEvent = new AiInteractionDeletedEvent(aiInteraction, "Mongo-History");
            _messagePublisher.Publish(aiInteractionDeletedEvent);

            await _repository.DeleteAsync(aiInteraction);

            return Ok(response);
        }
    }
}