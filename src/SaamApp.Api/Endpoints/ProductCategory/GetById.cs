using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ProductCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductCategoryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdProductCategoryRequest>.WithActionResult<
        GetByIdProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductCategory> _repository;

        public GetById(
            IRepository<ProductCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/productCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a ProductCategory by Id",
            Description = "Gets a ProductCategory by Id",
            OperationId = "productCategories.GetById",
            Tags = new[] { "ProductCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdProductCategoryResponse>> HandleAsync(
            [FromRoute] GetByIdProductCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdProductCategoryResponse(request.CorrelationId());

            var productCategory = await _repository.GetByIdAsync(request.RowId);
            if (productCategory is null)
            {
                return NotFound();
            }

            response.ProductCategory = _mapper.Map<ProductCategoryDto>(productCategory);

            return Ok(response);
        }
    }
}