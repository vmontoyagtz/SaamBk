using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAiRobotCategoryRequest>.WithActionResult<
        ListAiRobotCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiRobotCategory> _repository;

        public List(IRepository<AiRobotCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiRobotCategories")]
        [SwaggerOperation(
            Summary = "List AiRobotCategories",
            Description = "List AiRobotCategories",
            OperationId = "aiRobotCategories.List",
            Tags = new[] { "AiRobotCategoryEndpoints" })
        ]
        public override async Task<ActionResult<ListAiRobotCategoryResponse>> HandleAsync(
            [FromQuery] ListAiRobotCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiRobotCategoryResponse(request.CorrelationId());

            var spec = new AiRobotCategoryGetListSpec();
            var aiRobotCategories = await _repository.ListAsync(spec);
            if (aiRobotCategories is null)
            {
                return NotFound();
            }

            response.AiRobotCategories = _mapper.Map<List<AiRobotCategoryDto>>(aiRobotCategories);
            response.Count = response.AiRobotCategories.Count;

            return Ok(response);
        }
    }
}