using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiSessionEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAiSessionRequest>.WithActionResult<
        GetByIdAiSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiSession> _repository;

        public GetById(
            IRepository<AiSession> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiSessions/{AiSessionId}")]
        [SwaggerOperation(
            Summary = "Get a AiSession by Id",
            Description = "Gets a AiSession by Id",
            OperationId = "aiSessions.GetById",
            Tags = new[] { "AiSessionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiSessionResponse>> HandleAsync(
            [FromRoute] GetByIdAiSessionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiSessionResponse(request.CorrelationId());

            var aiSession = await _repository.GetByIdAsync(request.AiSessionId);
            if (aiSession is null)
            {
                return NotFound();
            }

            response.AiSession = _mapper.Map<AiSessionDto>(aiSession);

            return Ok(response);
        }
    }
}