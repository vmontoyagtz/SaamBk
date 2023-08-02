using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Category;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CategoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCategoryRequest>.WithActionResult<
        DeleteCategoryResponse>
    {
        private readonly IRepository<Category> _categoryReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryRepository;
        private readonly IRepository<Category> _repository;

        public Delete(IRepository<Category> CategoryRepository, IRepository<Category> CategoryReadRepository,
            IRepository<RegionAreaAdvisorCategory> regionAreaAdvisorCategoryRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CategoryRepository;
            _categoryReadRepository = CategoryReadRepository;
            _regionAreaAdvisorCategoryRepository = regionAreaAdvisorCategoryRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/categories/{CategoryId}")]
        [SwaggerOperation(
            Summary = "Deletes an Category",
            Description = "Deletes an Category",
            OperationId = "categories.delete",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCategoryResponse>> HandleAsync(
            [FromRoute] DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCategoryResponse(request.CorrelationId());

            var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                return NotFound();
            }

            var regionAreaAdvisorCategorySpec =
                new GetRegionAreaAdvisorCategoryWithCategoryKeySpec(category.CategoryId);
            var regionAreaAdvisorCategories =
                await _regionAreaAdvisorCategoryRepository.ListAsync(regionAreaAdvisorCategorySpec);
            await _regionAreaAdvisorCategoryRepository
                .DeleteRangeAsync(regionAreaAdvisorCategories); // you could use soft delete with IsDeleted = true

            var categoryDeletedEvent = new CategoryDeletedEvent(category, "Mongo-History");
            _messagePublisher.Publish(categoryDeletedEvent);

            await _repository.DeleteAsync(category);

            return Ok(response);
        }
    }
}