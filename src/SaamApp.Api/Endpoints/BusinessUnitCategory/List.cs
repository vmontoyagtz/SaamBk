using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListBusinessUnitCategoryRequest>.WithActionResult<
        ListBusinessUnitCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitCategory> _repository;

        public List(IRepository<BusinessUnitCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitCategories")]
        [SwaggerOperation(
            Summary = "List BusinessUnitCategories",
            Description = "List BusinessUnitCategories",
            OperationId = "businessUnitCategories.List",
            Tags = new[] { "BusinessUnitCategoryEndpoints" })
        ]
        public override async Task<ActionResult<ListBusinessUnitCategoryResponse>> HandleAsync(
            [FromQuery] ListBusinessUnitCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBusinessUnitCategoryResponse(request.CorrelationId());

            var spec = new BusinessUnitCategoryGetListSpec();
            var businessUnitCategories = await _repository.ListAsync(spec);
            if (businessUnitCategories is null)
            {
                return NotFound();
            }

            response.BusinessUnitCategories = _mapper.Map<List<BusinessUnitCategoryDto>>(businessUnitCategories);
            response.Count = response.BusinessUnitCategories.Count;

            return Ok(response);
        }
    }
}