using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TemplateCategoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTemplateCategoryRequest>.WithActionResult<
        UpdateTemplateCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateCategory> _repository;

        public Update(
            IRepository<TemplateCategory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/templateCategories")]
        [SwaggerOperation(
            Summary = "Updates a TemplateCategory",
            Description = "Updates a TemplateCategory",
            OperationId = "templateCategories.update",
            Tags = new[] { "TemplateCategoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTemplateCategoryResponse>> HandleAsync(
            UpdateTemplateCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTemplateCategoryResponse(request.CorrelationId());

            var tcecmcToUpdate = _mapper.Map<TemplateCategory>(request);

            var templateCategoryToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (templateCategoryToUpdateTest is null)
            {
                return NotFound();
            }

            tcecmcToUpdate.UpdateRegionAreaAdvisorCategoryForTemplateCategory(request.RegionAreaAdvisorCategoryId);
            tcecmcToUpdate.UpdateComissionForTemplateCategory(request.ComissionId);
            tcecmcToUpdate.UpdateTemplateForTemplateCategory(request.TemplateId);
            await _repository.UpdateAsync(tcecmcToUpdate);

            var templateCategoryUpdatedEvent = new TemplateCategoryUpdatedEvent(tcecmcToUpdate, "Mongo-History");
            _messagePublisher.Publish(templateCategoryUpdatedEvent);

            var dto = _mapper.Map<TemplateCategoryDto>(tcecmcToUpdate);
            response.TemplateCategory = dto;

            return Ok(response);
        }
    }
}