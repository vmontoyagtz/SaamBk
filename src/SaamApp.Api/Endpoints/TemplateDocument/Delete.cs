using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTemplateDocumentRequest>.WithActionResult<
        DeleteTemplateDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateDocument> _repository;
        private readonly IRepository<TemplateDocument> _templateDocumentReadRepository;

        public Delete(IRepository<TemplateDocument> TemplateDocumentRepository,
            IRepository<TemplateDocument> TemplateDocumentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TemplateDocumentRepository;
            _templateDocumentReadRepository = TemplateDocumentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/templateDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an TemplateDocument",
            Description = "Deletes an TemplateDocument",
            OperationId = "templateDocuments.delete",
            Tags = new[] { "TemplateDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTemplateDocumentResponse>> HandleAsync(
            [FromRoute] DeleteTemplateDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTemplateDocumentResponse(request.CorrelationId());

            var templateDocument = await _templateDocumentReadRepository.GetByIdAsync(request.RowId);

            if (templateDocument == null)
            {
                return NotFound();
            }


            var templateDocumentDeletedEvent = new TemplateDocumentDeletedEvent(templateDocument, "Mongo-History");
            _messagePublisher.Publish(templateDocumentDeletedEvent);

            await _repository.DeleteAsync(templateDocument);

            return Ok(response);
        }
    }
}