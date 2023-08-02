using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Product;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteProductRequest>.WithActionResult<
        DeleteProductResponse>
    {
        private readonly IRepository<InvoiceDetail> _invoiceDetailRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<Product> _productReadRepository;
        private readonly IRepository<Product> _repository;

        public Delete(IRepository<Product> ProductRepository, IRepository<Product> ProductReadRepository,
            IRepository<InvoiceDetail> invoiceDetailRepository,
            IRepository<Message> messageRepository,
            IRepository<ProductCategory> productCategoryRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ProductRepository;
            _productReadRepository = ProductReadRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _messageRepository = messageRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/products/{ProductId}")]
        [SwaggerOperation(
            Summary = "Deletes an Product",
            Description = "Deletes an Product",
            OperationId = "products.delete",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<DeleteProductResponse>> HandleAsync(
            [FromRoute] DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteProductResponse(request.CorrelationId());

            var product = await _productReadRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            var invoiceDetailSpec = new GetInvoiceDetailWithProductKeySpec(product.ProductId);
            var invoiceDetails = await _invoiceDetailRepository.ListAsync(invoiceDetailSpec);
            await _invoiceDetailRepository
                .DeleteRangeAsync(invoiceDetails); // you could use soft delete with IsDeleted = true
            var messageSpec = new GetMessageWithProductKeySpec(product.ProductId);
            var messages = await _messageRepository.ListAsync(messageSpec);
            await _messageRepository.DeleteRangeAsync(messages); // you could use soft delete with IsDeleted = true
            var productCategorySpec = new GetProductCategoryWithProductKeySpec(product.ProductId);
            var productCategories = await _productCategoryRepository.ListAsync(productCategorySpec);
            await _productCategoryRepository.DeleteRangeAsync(productCategories);

            var productDeletedEvent = new ProductDeletedEvent(product, "Mongo-History");
            _messagePublisher.Publish(productDeletedEvent);

            await _repository.DeleteAsync(product);

            return Ok(response);
        }
    }
}