using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobotCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotCategoryEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAiRobotCategoryRequest>.WithActionResult<
        GetByIdAiRobotCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiRobotCategory> _repository;

        public GetByRelsIds(
            IRepository<AiRobotCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiRobotCategories/{RegionAreaAdvisorCategoryId}/{ComissionId}/{AiRobotId}")]
        [SwaggerOperation(
            Summary = "Get a AiRobotCategory by rel Ids",
            Description = "Gets a AiRobotCategory by rel Ids",
            OperationId = "aiRobotCategories.GetByRelsIds",
            Tags = new[] { "AiRobotCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiRobotCategoryResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAiRobotCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiRobotCategoryResponse(request.CorrelationId());

            var spec = new AiRobotCategoryByRelIdsSpec(request.RegionAreaAdvisorCategoryId, request.ComissionId,
                request.AiRobotId);

            var aiRobotCategory = await _repository.FirstOrDefaultAsync(spec);


            if (aiRobotCategory is null)
            {
                return NotFound();
            }

            response.AiRobotCategory = _mapper.Map<AiRobotCategoryDto>(aiRobotCategory);

            return Ok(response);
        }
    }
}