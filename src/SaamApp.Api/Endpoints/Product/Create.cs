using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Product;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateProductRequest>.WithActionResult<
        CreateProductResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Product> _repository;

        public Create(
            IRepository<Product> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/products")]
        [SwaggerOperation(
            Summary = "Creates a new Product",
            Description = "Creates a new Product",
            OperationId = "products.create",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<CreateProductResponse>> HandleAsync(
            CreateProductRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateProductResponse(request.CorrelationId());


            var newProduct = new Product(
                Guid.NewGuid(),
                request.ProductName,
                request.ProductDescription,
                request.ProductUnitPrice,
                request.ProductIsActive,
                request.ProductMinimumCharacters,
                request.ProductMinimumCallMinutes,
                request.ProductChargeRatePerCharacter,
                request.ProductChargeRateCallPerSecond,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newProduct);

            _logger.LogInformation(
                $"Product created  with Id {newProduct.ProductId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ProductDto>(newProduct);

            var productCreatedEvent = new ProductCreatedEvent(newProduct, "Mongo-History");
            _messagePublisher.Publish(productCreatedEvent);

            response.Product = dto;


            return Ok(response);
        }
    }
}