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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdProductRequest>.WithActionResult<
        GetByIdProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public GetByIdWithIncludes(
            IRepository<Product> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/products/i/{ProductId}")]
        [SwaggerOperation(
            Summary = "Get a Product by Id With Includes",
            Description = "Gets a Product by Id With Includes",
            OperationId = "products.GetByIdWithIncludes",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdProductResponse>> HandleAsync(
            [FromRoute] GetByIdProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdProductResponse(request.CorrelationId());

            var spec = new ProductByIdWithIncludesSpec(request.ProductId);

            var product = await _repository.FirstOrDefaultAsync(spec);


            if (product is null)
            {
                return NotFound();
            }

            response.Product = _mapper.Map<ProductDto>(product);

            return Ok(response);
        }
    }
}