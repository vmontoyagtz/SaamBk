using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Template;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTemplateRequest>.WithActionResult<
        DeleteTemplateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Template> _repository;
        private readonly IRepository<TemplateCategory> _templateCategoryRepository;
        private readonly IRepository<TemplateDocument> _templateDocumentRepository;
        private readonly IRepository<Template> _templateReadRepository;

        public Delete(IRepository<Template> TemplateRepository, IRepository<Template> TemplateReadRepository,
            IRepository<TemplateCategory> templateCategoryRepository,
            IRepository<TemplateDocument> templateDocumentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TemplateRepository;
            _templateReadRepository = TemplateReadRepository;
            _templateCategoryRepository = templateCategoryRepository;
            _templateDocumentRepository = templateDocumentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/templates/{TemplateId}")]
        [SwaggerOperation(
            Summary = "Deletes an Template",
            Description = "Deletes an Template",
            OperationId = "templates.delete",
            Tags = new[] { "TemplateEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTemplateResponse>> HandleAsync(
            [FromRoute] DeleteTemplateRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTemplateResponse(request.CorrelationId());

            var template = await _templateReadRepository.GetByIdAsync(request.TemplateId);

            if (template == null)
            {
                return NotFound();
            }

            var templateCategorySpec = new GetTemplateCategoryWithTemplateKeySpec(template.TemplateId);
            var templateCategories = await _templateCategoryRepository.ListAsync(templateCategorySpec);
            await _templateCategoryRepository.DeleteRangeAsync(templateCategories);
            var templateDocumentSpec = new GetTemplateDocumentWithTemplateKeySpec(template.TemplateId);
            var templateDocuments = await _templateDocumentRepository.ListAsync(templateDocumentSpec);
            await _templateDocumentRepository.DeleteRangeAsync(templateDocuments);

            var templateDeletedEvent = new TemplateDeletedEvent(template, "Mongo-History");
            _messagePublisher.Publish(templateDeletedEvent);

            await _repository.DeleteAsync(template);

            return Ok(response);
        }
    }
}