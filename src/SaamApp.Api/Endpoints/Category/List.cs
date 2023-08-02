using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Category;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CategoryEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCategoryRequest>.WithActionResult<ListCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;

        public List(IRepository<Category> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/categories")]
        [SwaggerOperation(
            Summary = "List Categories",
            Description = "List Categories",
            OperationId = "categories.List",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<ListCategoryResponse>> HandleAsync(
            [FromQuery] ListCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCategoryResponse(request.CorrelationId());

            var spec = new CategoryGetListSpec();
            var categories = await _repository.ListAsync(spec);
            if (categories is null)
            {
                return NotFound();
            }

            response.Categories = _mapper.Map<List<CategoryDto>>(categories);
            response.Count = response.Categories.Count;

            return Ok(response);
        }
    }
}