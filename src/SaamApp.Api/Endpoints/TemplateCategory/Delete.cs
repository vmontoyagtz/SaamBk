using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateCategoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTemplateCategoryRequest>.WithActionResult<
        DeleteTemplateCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateCategory> _repository;
        private readonly IRepository<TemplateCategory> _templateCategoryReadRepository;

        public Delete(IRepository<TemplateCategory> TemplateCategoryRepository,
            IRepository<TemplateCategory> TemplateCategoryReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TemplateCategoryRepository;
            _templateCategoryReadRepository = TemplateCategoryReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/templateCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an TemplateCategory",
            Description = "Deletes an TemplateCategory",
            OperationId = "templateCategories.delete",
            Tags = new[] { "TemplateCategoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTemplateCategoryResponse>> HandleAsync(
            [FromRoute] DeleteTemplateCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTemplateCategoryResponse(request.CorrelationId());

            var templateCategory = await _templateCategoryReadRepository.GetByIdAsync(request.RowId);

            if (templateCategory == null)
            {
                return NotFound();
            }


            var templateCategoryDeletedEvent = new TemplateCategoryDeletedEvent(templateCategory, "Mongo-History");
            _messagePublisher.Publish(templateCategoryDeletedEvent);

            await _repository.DeleteAsync(templateCategory);

            return Ok(response);
        }
    }
}