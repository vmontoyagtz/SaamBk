using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.UserSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UserSessionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateUserSessionRequest>.WithActionResult<
        CreateUserSessionResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<UserSession> _repository;

        public Create(
            IRepository<UserSession> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/userSessions")]
        [SwaggerOperation(
            Summary = "Creates a new UserSession",
            Description = "Creates a new UserSession",
            OperationId = "userSessions.create",
            Tags = new[] { "UserSessionEndpoints" })
        ]
        public override async Task<ActionResult<CreateUserSessionResponse>> HandleAsync(
            CreateUserSessionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateUserSessionResponse(request.CorrelationId());


            var newUserSession = new UserSession(
                Guid.NewGuid(),
                request.ApplicationUserId,
                request.LoginTime,
                request.LogoutTime,
                request.TenantId
            );


            await _repository.AddAsync(newUserSession);

            _logger.LogInformation(
                $"UserSession created  with Id {newUserSession.SessionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<UserSessionDto>(newUserSession);

            var userSessionCreatedEvent = new UserSessionCreatedEvent(newUserSession, "Mongo-History");
            _messagePublisher.Publish(userSessionCreatedEvent);

            response.UserSession = dto;


            return Ok(response);
        }
    }
}