using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitCategoryEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsBusinessUnitCategoryRequest>.WithActionResult<
        GetByIdBusinessUnitCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitCategory> _repository;

        public GetByRelsIds(
            IRepository<BusinessUnitCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitCategories/{RegionAreaAdvisorCategoryId}/{BusinessUnitId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitCategory by rel Ids",
            Description = "Gets a BusinessUnitCategory by rel Ids",
            OperationId = "businessUnitCategories.GetByRelsIds",
            Tags = new[] { "BusinessUnitCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitCategoryResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsBusinessUnitCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitCategoryResponse(request.CorrelationId());

            var spec = new BusinessUnitCategoryByRelIdsSpec(request.RegionAreaAdvisorCategoryId,
                request.BusinessUnitId);

            var businessUnitCategory = await _repository.FirstOrDefaultAsync(spec);


            if (businessUnitCategory is null)
            {
                return NotFound();
            }

            response.BusinessUnitCategory = _mapper.Map<BusinessUnitCategoryDto>(businessUnitCategory);

            return Ok(response);
        }
    }
}