using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TemplateDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTemplateDocumentRequest>.WithActionResult<
        UpdateTemplateDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateDocument> _repository;

        public Update(
            IRepository<TemplateDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/templateDocuments")]
        [SwaggerOperation(
            Summary = "Updates a TemplateDocument",
            Description = "Updates a TemplateDocument",
            OperationId = "templateDocuments.update",
            Tags = new[] { "TemplateDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTemplateDocumentResponse>> HandleAsync(
            UpdateTemplateDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTemplateDocumentResponse(request.CorrelationId());

            var tdedmdToUpdate = _mapper.Map<TemplateDocument>(request);

            var templateDocumentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (templateDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            //tdedmdToUpdate.UpdateDocumentForTemplateDocument(request.DocumentId);
            //tdedmdToUpdate.UpdateDocumentTypeForTemplateDocument(request.DocumentTypeId);
            //tdedmdToUpdate.UpdateTemplateForTemplateDocument(request.TemplateId);
            await _repository.UpdateAsync(tdedmdToUpdate);

            var templateDocumentUpdatedEvent = new TemplateDocumentUpdatedEvent(tdedmdToUpdate, "Mongo-History");
            _messagePublisher.Publish(templateDocumentUpdatedEvent);

            var dto = _mapper.Map<TemplateDocumentDto>(tdedmdToUpdate);
            response.TemplateDocument = dto;

            return Ok(response);
        }
    }
}