using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiModel;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiModelEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAiModelRequest>.WithActionResult<
        GetByIdAiModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiModel> _repository;

        public GetById(
            IRepository<AiModel> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiModels/{AiModelId}")]
        [SwaggerOperation(
            Summary = "Get a AiModel by Id",
            Description = "Gets a AiModel by Id",
            OperationId = "aiModels.GetById",
            Tags = new[] { "AiModelEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiModelResponse>> HandleAsync(
            [FromRoute] GetByIdAiModelRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiModelResponse(request.CorrelationId());

            var aiModel = await _repository.GetByIdAsync(request.AiModelId);
            if (aiModel is null)
            {
                return NotFound();
            }

            response.AiModel = _mapper.Map<AiModelDto>(aiModel);

            return Ok(response);
        }
    }
}