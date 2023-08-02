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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCategoryRequest>.WithActionResult<
        GetByIdCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;

        public GetByIdWithIncludes(
            IRepository<Category> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/categories/i/{CategoryId}")]
        [SwaggerOperation(
            Summary = "Get a Category by Id With Includes",
            Description = "Gets a Category by Id With Includes",
            OperationId = "categories.GetByIdWithIncludes",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCategoryResponse>> HandleAsync(
            [FromRoute] GetByIdCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCategoryResponse(request.CorrelationId());

            var spec = new CategoryByIdWithIncludesSpec(request.CategoryId);

            var category = await _repository.FirstOrDefaultAsync(spec);


            if (category is null)
            {
                return NotFound();
            }

            response.Category = _mapper.Map<CategoryDto>(category);

            return Ok(response);
        }
    }
}