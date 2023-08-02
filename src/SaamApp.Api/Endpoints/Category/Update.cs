using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Category;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CategoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCategoryRequest>.WithActionResult<UpdateCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Category> _repository;

        public Update(
            IRepository<Category> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/categories")]
        [SwaggerOperation(
            Summary = "Updates a Category",
            Description = "Updates a Category",
            OperationId = "categories.update",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCategoryResponse>> HandleAsync(UpdateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateCategoryResponse(request.CorrelationId());

            var catToUpdate = _mapper.Map<Category>(request);

            var categoryToUpdateTest = await _repository.GetByIdAsync(request.CategoryId);
            if (categoryToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(catToUpdate);

            var categoryUpdatedEvent = new CategoryUpdatedEvent(catToUpdate, "Mongo-History");
            _messagePublisher.Publish(categoryUpdatedEvent);

            var dto = _mapper.Map<CategoryDto>(catToUpdate);
            response.Category = dto;

            return Ok(response);
        }
    }
}