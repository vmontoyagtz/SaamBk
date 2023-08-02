using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiMemory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiMemoryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAiMemoryRequest>.WithActionResult<
        GetByIdAiMemoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiMemory> _repository;

        public GetById(
            IRepository<AiMemory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiMemories/{AiMemoryId}")]
        [SwaggerOperation(
            Summary = "Get a AiMemory by Id",
            Description = "Gets a AiMemory by Id",
            OperationId = "aiMemories.GetById",
            Tags = new[] { "AiMemoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiMemoryResponse>> HandleAsync(
            [FromRoute] GetByIdAiMemoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiMemoryResponse(request.CorrelationId());

            var aiMemory = await _repository.GetByIdAsync(request.AiMemoryId);
            if (aiMemory is null)
            {
                return NotFound();
            }

            response.AiMemory = _mapper.Map<AiMemoryDto>(aiMemory);

            return Ok(response);
        }
    }
}