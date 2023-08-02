using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UserSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.UserSessionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateUserSessionRequest>.WithActionResult<
        UpdateUserSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<UserSession> _repository;

        public Update(
            IRepository<UserSession> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/userSessions")]
        [SwaggerOperation(
            Summary = "Updates a UserSession",
            Description = "Updates a UserSession",
            OperationId = "userSessions.update",
            Tags = new[] { "UserSessionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateUserSessionResponse>> HandleAsync(
            UpdateUserSessionRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserSessionResponse(request.CorrelationId());

            var usssesToUpdate = _mapper.Map<UserSession>(request);

            var userSessionToUpdateTest = await _repository.GetByIdAsync(request.SessionId);
            if (userSessionToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(usssesToUpdate);

            var userSessionUpdatedEvent = new UserSessionUpdatedEvent(usssesToUpdate, "Mongo-History");
            _messagePublisher.Publish(userSessionUpdatedEvent);

            var dto = _mapper.Map<UserSessionDto>(usssesToUpdate);
            response.UserSession = dto;

            return Ok(response);
        }
    }
}