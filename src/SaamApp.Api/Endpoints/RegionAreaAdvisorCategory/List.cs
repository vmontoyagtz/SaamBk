using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListRegionAreaAdvisorCategoryRequest>.WithActionResult<
        ListRegionAreaAdvisorCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<RegionAreaAdvisorCategory> _repository;

        public List(IRepository<RegionAreaAdvisorCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/regionAreaAdvisorCategories")]
        [SwaggerOperation(
            Summary = "List RegionAreaAdvisorCategories",
            Description = "List RegionAreaAdvisorCategories",
            OperationId = "regionAreaAdvisorCategories.List",
            Tags = new[] { "RegionAreaAdvisorCategoryEndpoints" })
        ]
        public override async Task<ActionResult<ListRegionAreaAdvisorCategoryResponse>> HandleAsync(
            [FromQuery] ListRegionAreaAdvisorCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListRegionAreaAdvisorCategoryResponse(request.CorrelationId());

            var spec = new RegionAreaAdvisorCategoryGetListSpec();
            var regionAreaAdvisorCategories = await _repository.ListAsync(spec);
            if (regionAreaAdvisorCategories is null)
            {
                return NotFound();
            }

            response.RegionAreaAdvisorCategories =
                _mapper.Map<List<RegionAreaAdvisorCategoryDto>>(regionAreaAdvisorCategories);
            response.Count = response.RegionAreaAdvisorCategories.Count;

            return Ok(response);
        }
    }
}