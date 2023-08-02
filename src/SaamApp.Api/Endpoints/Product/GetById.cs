using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Product;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdProductRequest>.WithActionResult<
        GetByIdProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public GetById(
            IRepository<Product> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/products/{ProductId}")]
        [SwaggerOperation(
            Summary = "Get a Product by Id",
            Description = "Gets a Product by Id",
            OperationId = "products.GetById",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdProductResponse>> HandleAsync(
            [FromRoute] GetByIdProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdProductResponse(request.CorrelationId());

            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product is null)
            {
                return NotFound();
            }

            response.Product = _mapper.Map<ProductDto>(product);

            return Ok(response);
        }
    }
}