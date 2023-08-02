using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Product;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ProductEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateProductRequest>.WithActionResult<UpdateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Product> _repository;

        public Update(
            IRepository<Product> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/products")]
        [SwaggerOperation(
            Summary = "Updates a Product",
            Description = "Updates a Product",
            OperationId = "products.update",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<UpdateProductResponse>> HandleAsync(UpdateProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateProductResponse(request.CorrelationId());

            var proToUpdate = _mapper.Map<Product>(request);

            var productToUpdateTest = await _repository.GetByIdAsync(request.ProductId);
            if (productToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(proToUpdate);

            var productUpdatedEvent = new ProductUpdatedEvent(proToUpdate, "Mongo-History");
            _messagePublisher.Publish(productUpdatedEvent);

            var dto = _mapper.Map<ProductDto>(proToUpdate);
            response.Product = dto;

            return Ok(response);
        }
    }
}