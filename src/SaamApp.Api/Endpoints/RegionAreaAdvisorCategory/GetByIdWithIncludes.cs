using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RegionAreaAdvisorCategoryEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdRegionAreaAdvisorCategoryRequest>.
        WithActionResult<
            GetByIdRegionAreaAdvisorCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RegionAreaAdvisorCategory> _repository;

        public GetByIdWithIncludes(
            IRepository<RegionAreaAdvisorCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/regionAreaAdvisorCategories/i/{RegionAreaAdvisorCategoryId}")]
        [SwaggerOperation(
            Summary = "Get a RegionAreaAdvisorCategory by Id With Includes",
            Description = "Gets a RegionAreaAdvisorCategory by Id With Includes",
            OperationId = "regionAreaAdvisorCategories.GetByIdWithIncludes",
            Tags = new[] { "RegionAreaAdvisorCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdRegionAreaAdvisorCategoryResponse>> HandleAsync(
            [FromRoute] GetByIdRegionAreaAdvisorCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdRegionAreaAdvisorCategoryResponse(request.CorrelationId());

            var spec = new RegionAreaAdvisorCategoryByIdWithIncludesSpec(request.RegionAreaAdvisorCategoryId);

            var regionAreaAdvisorCategory = await _repository.FirstOrDefaultAsync(spec);


            if (regionAreaAdvisorCategory is null)
            {
                return NotFound();
            }

            response.RegionAreaAdvisorCategory = _mapper.Map<RegionAreaAdvisorCategoryDto>(regionAreaAdvisorCategory);

            return Ok(response);
        }
    }
}