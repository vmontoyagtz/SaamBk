using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ProductCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductCategoryEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListProductCategoryRequest>.WithActionResult<
        ListProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductCategory> _repository;

        public List(IRepository<ProductCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/productCategories")]
        [SwaggerOperation(
            Summary = "List ProductCategories",
            Description = "List ProductCategories",
            OperationId = "productCategories.List",
            Tags = new[] { "ProductCategoryEndpoints" })
        ]
        public override async Task<ActionResult<ListProductCategoryResponse>> HandleAsync(
            [FromQuery] ListProductCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListProductCategoryResponse(request.CorrelationId());

            var spec = new ProductCategoryGetListSpec();
            var productCategories = await _repository.ListAsync(spec);
            if (productCategories is null)
            {
                return NotFound();
            }

            response.ProductCategories = _mapper.Map<List<ProductCategoryDto>>(productCategories);
            response.Count = response.ProductCategories.Count;

            return Ok(response);
        }
    }
}