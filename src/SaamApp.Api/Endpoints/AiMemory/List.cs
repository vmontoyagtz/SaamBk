using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiMemory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiMemoryEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAiMemoryRequest>.WithActionResult<ListAiMemoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiMemory> _repository;

        public List(IRepository<AiMemory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiMemories")]
        [SwaggerOperation(
            Summary = "List AiMemories",
            Description = "List AiMemories",
            OperationId = "aiMemories.List",
            Tags = new[] { "AiMemoryEndpoints" })
        ]
        public override async Task<ActionResult<ListAiMemoryResponse>> HandleAsync(
            [FromQuery] ListAiMemoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiMemoryResponse(request.CorrelationId());

            var spec = new AiMemoryGetListSpec();
            var aiMemories = await _repository.ListAsync(spec);
            if (aiMemories is null)
            {
                return NotFound();
            }

            response.AiMemories = _mapper.Map<List<AiMemoryDto>>(aiMemories);
            response.Count = response.AiMemories.Count;

            return Ok(response);
        }
    }
}