using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAiErrorLogRequest>.WithActionResult<ListAiErrorLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiErrorLog> _repository;

        public List(IRepository<AiErrorLog> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiErrorLogs")]
        [SwaggerOperation(
            Summary = "List AiErrorLogs",
            Description = "List AiErrorLogs",
            OperationId = "aiErrorLogs.List",
            Tags = new[] { "AiErrorLogEndpoints" })
        ]
        public override async Task<ActionResult<ListAiErrorLogResponse>> HandleAsync(
            [FromQuery] ListAiErrorLogRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiErrorLogResponse(request.CorrelationId());

            var spec = new AiErrorLogGetListSpec();
            var aiErrorLogs = await _repository.ListAsync(spec);
            if (aiErrorLogs is null)
            {
                return NotFound();
            }

            response.AiErrorLogs = _mapper.Map<List<AiErrorLogDto>>(aiErrorLogs);
            response.Count = response.AiErrorLogs.Count;

            return Ok(response);
        }
    }
}