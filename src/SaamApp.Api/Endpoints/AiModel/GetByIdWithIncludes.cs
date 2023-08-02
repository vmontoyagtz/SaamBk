using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiModel;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiModelEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAiModelRequest>.WithActionResult<
        GetByIdAiModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiModel> _repository;

        public GetByIdWithIncludes(
            IRepository<AiModel> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiModels/i/{AiModelId}")]
        [SwaggerOperation(
            Summary = "Get a AiModel by Id With Includes",
            Description = "Gets a AiModel by Id With Includes",
            OperationId = "aiModels.GetByIdWithIncludes",
            Tags = new[] { "AiModelEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiModelResponse>> HandleAsync(
            [FromRoute] GetByIdAiModelRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiModelResponse(request.CorrelationId());

            var spec = new AiModelByIdWithIncludesSpec(request.AiModelId);

            var aiModel = await _repository.FirstOrDefaultAsync(spec);


            if (aiModel is null)
            {
                return NotFound();
            }

            response.AiModel = _mapper.Map<AiModelDto>(aiModel);

            return Ok(response);
        }
    }
}