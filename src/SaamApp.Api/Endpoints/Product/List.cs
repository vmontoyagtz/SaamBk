using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Product;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListProductRequest>.WithActionResult<ListProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public List(IRepository<Product> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/products")]
        [SwaggerOperation(
            Summary = "List Products",
            Description = "List Products",
            OperationId = "products.List",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<ListProductResponse>> HandleAsync(
            [FromQuery] ListProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListProductResponse(request.CorrelationId());

            var spec = new ProductGetListSpec();
            var products = await _repository.ListAsync(spec);
            if (products is null)
            {
                return NotFound();
            }

            response.Products = _mapper.Map<List<ProductDto>>(products);
            response.Count = response.Products.Count;

            return Ok(response);
        }
    }
}