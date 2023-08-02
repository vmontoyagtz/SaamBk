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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAiSessionRequest>.WithActionResult<
        GetByIdAiSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiSession> _repository;

        public GetByIdWithIncludes(
            IRepository<AiSession> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiSessions/i/{AiSessionId}")]
        [SwaggerOperation(
            Summary = "Get a AiSession by Id With Includes",
            Description = "Gets a AiSession by Id With Includes",
            OperationId = "aiSessions.GetByIdWithIncludes",
            Tags = new[] { "AiSessionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiSessionResponse>> HandleAsync(
            [FromRoute] GetByIdAiSessionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiSessionResponse(request.CorrelationId());

            var spec = new AiSessionByIdWithIncludesSpec(request.AiSessionId);

            var aiSession = await _repository.FirstOrDefaultAsync(spec);


            if (aiSession is null)
            {
                return NotFound();
            }

            response.AiSession = _mapper.Map<AiSessionDto>(aiSession);

            return Ok(response);
        }
    }
}