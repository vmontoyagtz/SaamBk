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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAiMemoryRequest>.WithActionResult<
        GetByIdAiMemoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiMemory> _repository;

        public GetByIdWithIncludes(
            IRepository<AiMemory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiMemories/i/{AiMemoryId}")]
        [SwaggerOperation(
            Summary = "Get a AiMemory by Id With Includes",
            Description = "Gets a AiMemory by Id With Includes",
            OperationId = "aiMemories.GetByIdWithIncludes",
            Tags = new[] { "AiMemoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiMemoryResponse>> HandleAsync(
            [FromRoute] GetByIdAiMemoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiMemoryResponse(request.CorrelationId());

            var spec = new AiMemoryByIdWithIncludesSpec(request.AiMemoryId);

            var aiMemory = await _repository.FirstOrDefaultAsync(spec);


            if (aiMemory is null)
            {
                return NotFound();
            }

            response.AiMemory = _mapper.Map<AiMemoryDto>(aiMemory);

            return Ok(response);
        }
    }
}