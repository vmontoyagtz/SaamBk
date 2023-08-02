using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiSessionEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAiSessionRequest>.WithActionResult<ListAiSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiSession> _repository;

        public List(IRepository<AiSession> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiSessions")]
        [SwaggerOperation(
            Summary = "List AiSessions",
            Description = "List AiSessions",
            OperationId = "aiSessions.List",
            Tags = new[] { "AiSessionEndpoints" })
        ]
        public override async Task<ActionResult<ListAiSessionResponse>> HandleAsync(
            [FromQuery] ListAiSessionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiSessionResponse(request.CorrelationId());

            var spec = new AiSessionGetListSpec();
            var aiSessions = await _repository.ListAsync(spec);
            if (aiSessions is null)
            {
                return NotFound();
            }

            response.AiSessions = _mapper.Map<List<AiSessionDto>>(aiSessions);
            response.Count = response.AiSessions.Count;

            return Ok(response);
        }
    }
}