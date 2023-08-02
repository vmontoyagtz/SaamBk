using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiErrorLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiErrorLogEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAiErrorLogRequest>.WithActionResult<
        GetByIdAiErrorLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiErrorLog> _repository;

        public GetByIdWithIncludes(
            IRepository<AiErrorLog> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiErrorLogs/i/{AiErrorLogId}")]
        [SwaggerOperation(
            Summary = "Get a AiErrorLog by Id With Includes",
            Description = "Gets a AiErrorLog by Id With Includes",
            OperationId = "aiErrorLogs.GetByIdWithIncludes",
            Tags = new[] { "AiErrorLogEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiErrorLogResponse>> HandleAsync(
            [FromRoute] GetByIdAiErrorLogRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiErrorLogResponse(request.CorrelationId());

            var spec = new AiErrorLogByIdWithIncludesSpec(request.AiErrorLogId);

            var aiErrorLog = await _repository.FirstOrDefaultAsync(spec);


            if (aiErrorLog is null)
            {
                return NotFound();
            }

            response.AiErrorLog = _mapper.Map<AiErrorLogDto>(aiErrorLog);

            return Ok(response);
        }
    }
}