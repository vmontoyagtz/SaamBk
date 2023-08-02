using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UserSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.UserSessionEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListUserSessionRequest>.WithActionResult<ListUserSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserSession> _repository;

        public List(IRepository<UserSession> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/userSessions")]
        [SwaggerOperation(
            Summary = "List UserSessions",
            Description = "List UserSessions",
            OperationId = "userSessions.List",
            Tags = new[] { "UserSessionEndpoints" })
        ]
        public override async Task<ActionResult<ListUserSessionResponse>> HandleAsync(
            [FromQuery] ListUserSessionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListUserSessionResponse(request.CorrelationId());

            var spec = new UserSessionGetListSpec();
            var userSessions = await _repository.ListAsync(spec);
            if (userSessions is null)
            {
                return NotFound();
            }

            response.UserSessions = _mapper.Map<List<UserSessionDto>>(userSessions);
            response.Count = response.UserSessions.Count;

            return Ok(response);
        }
    }
}