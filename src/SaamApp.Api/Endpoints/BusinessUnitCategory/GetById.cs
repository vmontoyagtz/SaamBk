using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitCategoryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBusinessUnitCategoryRequest>.WithActionResult<
        GetByIdBusinessUnitCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitCategory> _repository;

        public GetById(
            IRepository<BusinessUnitCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitCategory by Id",
            Description = "Gets a BusinessUnitCategory by Id",
            OperationId = "businessUnitCategories.GetById",
            Tags = new[] { "BusinessUnitCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitCategoryResponse>> HandleAsync(
            [FromRoute] GetByIdBusinessUnitCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitCategoryResponse(request.CorrelationId());

            var businessUnitCategory = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitCategory is null)
            {
                return NotFound();
            }

            response.BusinessUnitCategory = _mapper.Map<BusinessUnitCategoryDto>(businessUnitCategory);

            return Ok(response);
        }
    }
}