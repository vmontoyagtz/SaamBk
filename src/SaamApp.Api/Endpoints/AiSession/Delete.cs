using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiSessionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiSessionRequest>.WithActionResult<
        DeleteAiSessionResponse>
    {
        private readonly IRepository<AiSession> _aiSessionReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiSession> _repository;

        public Delete(IRepository<AiSession> AiSessionRepository, IRepository<AiSession> AiSessionReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiSessionRepository;
            _aiSessionReadRepository = AiSessionReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiSessions/{AiSessionId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiSession",
            Description = "Deletes an AiSession",
            OperationId = "aiSessions.delete",
            Tags = new[] { "AiSessionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiSessionResponse>> HandleAsync(
            [FromRoute] DeleteAiSessionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiSessionResponse(request.CorrelationId());

            var aiSession = await _aiSessionReadRepository.GetByIdAsync(request.AiSessionId);

            if (aiSession == null)
            {
                return NotFound();
            }


            var aiSessionDeletedEvent = new AiSessionDeletedEvent(aiSession, "Mongo-History");
            _messagePublisher.Publish(aiSessionDeletedEvent);

            await _repository.DeleteAsync(aiSession);

            return Ok(response);
        }
    }
}