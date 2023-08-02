using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobotCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotCategoryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAiRobotCategoryRequest>.WithActionResult<
        GetByIdAiRobotCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiRobotCategory> _repository;

        public GetById(
            IRepository<AiRobotCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiRobotCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AiRobotCategory by Id",
            Description = "Gets a AiRobotCategory by Id",
            OperationId = "aiRobotCategories.GetById",
            Tags = new[] { "AiRobotCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiRobotCategoryResponse>> HandleAsync(
            [FromRoute] GetByIdAiRobotCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiRobotCategoryResponse(request.CorrelationId());

            var aiRobotCategory = await _repository.GetByIdAsync(request.RowId);
            if (aiRobotCategory is null)
            {
                return NotFound();
            }

            response.AiRobotCategory = _mapper.Map<AiRobotCategoryDto>(aiRobotCategory);

            return Ok(response);
        }
    }
}