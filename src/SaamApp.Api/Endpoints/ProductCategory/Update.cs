using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ProductCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ProductCategoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateProductCategoryRequest>.WithActionResult<
        UpdateProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ProductCategory> _repository;

        public Update(
            IRepository<ProductCategory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/productCategories")]
        [SwaggerOperation(
            Summary = "Updates a ProductCategory",
            Description = "Updates a ProductCategory",
            OperationId = "productCategories.update",
            Tags = new[] { "ProductCategoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateProductCategoryResponse>> HandleAsync(
            UpdateProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateProductCategoryResponse(request.CorrelationId());

            var pcrcocToUpdate = _mapper.Map<ProductCategory>(request);

            var productCategoryToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (productCategoryToUpdateTest is null)
            {
                return NotFound();
            }

            pcrcocToUpdate.UpdateRegionAreaAdvisorCategoryForProductCategory(request.RegionAreaAdvisorCategoryId);
            pcrcocToUpdate.UpdateComissionForProductCategory(request.ComissionId);
            pcrcocToUpdate.UpdateProductForProductCategory(request.ProductId);
            await _repository.UpdateAsync(pcrcocToUpdate);

            var productCategoryUpdatedEvent = new ProductCategoryUpdatedEvent(pcrcocToUpdate, "Mongo-History");
            _messagePublisher.Publish(productCategoryUpdatedEvent);

            var dto = _mapper.Map<ProductCategoryDto>(pcrcocToUpdate);
            response.ProductCategory = dto;

            return Ok(response);
        }
    }
}