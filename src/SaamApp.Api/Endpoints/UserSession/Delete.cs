using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UserSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UserSessionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteUserSessionRequest>.WithActionResult<
        DeleteUserSessionResponse>
    {
        private readonly IRepository<AiInteraction> _aiInteractionRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<UserSession> _repository;
        private readonly IRepository<UserSession> _userSessionReadRepository;

        public Delete(IRepository<UserSession> UserSessionRepository,
            IRepository<UserSession> UserSessionReadRepository,
            IRepository<AiInteraction> aiInteractionRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = UserSessionRepository;
            _userSessionReadRepository = UserSessionReadRepository;
            _aiInteractionRepository = aiInteractionRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/userSessions/{SessionId}")]
        [SwaggerOperation(
            Summary = "Deletes an UserSession",
            Description = "Deletes an UserSession",
            OperationId = "userSessions.delete",
            Tags = new[] { "UserSessionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteUserSessionResponse>> HandleAsync(
            [FromRoute] DeleteUserSessionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserSessionResponse(request.CorrelationId());

            var userSession = await _userSessionReadRepository.GetByIdAsync(request.SessionId);

            if (userSession == null)
            {
                return NotFound();
            }

            var aiInteractionSpec = new GetAiInteractionWithUserSessionKeySpec(userSession.SessionId);
            var aiInteractions = await _aiInteractionRepository.ListAsync(aiInteractionSpec);
            await _aiInteractionRepository
                .DeleteRangeAsync(aiInteractions); // you could use soft delete with IsDeleted = true

            var userSessionDeletedEvent = new UserSessionDeletedEvent(userSession, "Mongo-History");
            _messagePublisher.Publish(userSessionDeletedEvent);

            await _repository.DeleteAsync(userSession);

            return Ok(response);
        }
    }
}