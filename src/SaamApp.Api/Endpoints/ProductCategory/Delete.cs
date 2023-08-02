using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ProductCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductCategoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteProductCategoryRequest>.WithActionResult<
        DeleteProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ProductCategory> _productCategoryReadRepository;
        private readonly IRepository<ProductCategory> _repository;

        public Delete(IRepository<ProductCategory> ProductCategoryRepository,
            IRepository<ProductCategory> ProductCategoryReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ProductCategoryRepository;
            _productCategoryReadRepository = ProductCategoryReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/productCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an ProductCategory",
            Description = "Deletes an ProductCategory",
            OperationId = "productCategories.delete",
            Tags = new[] { "ProductCategoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteProductCategoryResponse>> HandleAsync(
            [FromRoute] DeleteProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteProductCategoryResponse(request.CorrelationId());

            var productCategory = await _productCategoryReadRepository.GetByIdAsync(request.RowId);

            if (productCategory == null)
            {
                return NotFound();
            }


            var productCategoryDeletedEvent = new ProductCategoryDeletedEvent(productCategory, "Mongo-History");
            _messagePublisher.Publish(productCategoryDeletedEvent);

            await _repository.DeleteAsync(productCategory);

            return Ok(response);
        }
    }
}