using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UserSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UserSessionEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdUserSessionRequest>.WithActionResult<
        GetByIdUserSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserSession> _repository;

        public GetById(
            IRepository<UserSession> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/userSessions/{SessionId}")]
        [SwaggerOperation(
            Summary = "Get a UserSession by Id",
            Description = "Gets a UserSession by Id",
            OperationId = "userSessions.GetById",
            Tags = new[] { "UserSessionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdUserSessionResponse>> HandleAsync(
            [FromRoute] GetByIdUserSessionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdUserSessionResponse(request.CorrelationId());

            var userSession = await _repository.GetByIdAsync(request.SessionId);
            if (userSession is null)
            {
                return NotFound();
            }

            response.UserSession = _mapper.Map<UserSessionDto>(userSession);

            return Ok(response);
        }
    }
}