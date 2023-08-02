using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAiModelRequest>.WithActionResult<ListAiModelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiModel> _repository;

        public List(IRepository<AiModel> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiModels")]
        [SwaggerOperation(
            Summary = "List AiModels",
            Description = "List AiModels",
            OperationId = "aiModels.List",
            Tags = new[] { "AiModelEndpoints" })
        ]
        public override async Task<ActionResult<ListAiModelResponse>> HandleAsync(
            [FromQuery] ListAiModelRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiModelResponse(request.CorrelationId());

            var spec = new AiModelGetListSpec();
            var aiModels = await _repository.ListAsync(spec);
            if (aiModels is null)
            {
                return NotFound();
            }

            response.AiModels = _mapper.Map<List<AiModelDto>>(aiModels);
            response.Count = response.AiModels.Count;

            return Ok(response);
        }
    }
}