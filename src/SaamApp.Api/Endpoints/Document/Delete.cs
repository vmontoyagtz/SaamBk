using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Document;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteDocumentRequest>.WithActionResult<
        DeleteDocumentResponse>
    {
        private readonly IRepository<AdvisorDocument> _advisorDocumentRepository;
        private readonly IRepository<AdvisorIdentityDocument> _advisorIdentityDocumentRepository;
        private readonly IRepository<BusinessUnitDocument> _businessUnitDocumentRepository;
        private readonly IRepository<CustomerDocument> _customerDocumentRepository;
        private readonly IRepository<Document> _documentReadRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<MessageDocument> _messageDocumentRepository;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Document> _repository;
        private readonly IRepository<TemplateDocument> _templateDocumentRepository;
        private readonly IRepository<VoiceNoteDocument> _voiceNoteDocumentRepository;

        public Delete(IRepository<Document> DocumentRepository, IRepository<Document> DocumentReadRepository,
            IRepository<AdvisorDocument> advisorDocumentRepository,
            IRepository<AdvisorIdentityDocument> advisorIdentityDocumentRepository,
            IRepository<BusinessUnitDocument> businessUnitDocumentRepository,
            IRepository<CustomerDocument> customerDocumentRepository,
            IRepository<MessageDocument> messageDocumentRepository,
            IRepository<TemplateDocument> templateDocumentRepository,
            IRepository<VoiceNoteDocument> voiceNoteDocumentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = DocumentRepository;
            _documentReadRepository = DocumentReadRepository;
            _advisorDocumentRepository = advisorDocumentRepository;
            _advisorIdentityDocumentRepository = advisorIdentityDocumentRepository;
            _businessUnitDocumentRepository = businessUnitDocumentRepository;
            _customerDocumentRepository = customerDocumentRepository;
            _messageDocumentRepository = messageDocumentRepository;
            _templateDocumentRepository = templateDocumentRepository;
            _voiceNoteDocumentRepository = voiceNoteDocumentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/documents/{DocumentId}")]
        [SwaggerOperation(
            Summary = "Deletes an Document",
            Description = "Deletes an Document",
            OperationId = "documents.delete",
            Tags = new[] { "DocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteDocumentResponse>> HandleAsync(
            [FromRoute] DeleteDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteDocumentResponse(request.CorrelationId());

            var document = await _documentReadRepository.GetByIdAsync(request.DocumentId);

            if (document == null)
            {
                return NotFound();
            }

            var advisorDocumentSpec = new GetAdvisorDocumentWithDocumentKeySpec(document.DocumentId);
            var advisorDocuments = await _advisorDocumentRepository.ListAsync(advisorDocumentSpec);
            await _advisorDocumentRepository.DeleteRangeAsync(advisorDocuments);
            var advisorIdentityDocumentSpec = new GetAdvisorIdentityDocumentWithDocumentKeySpec(document.DocumentId);
            var advisorIdentityDocuments =
                await _advisorIdentityDocumentRepository.ListAsync(advisorIdentityDocumentSpec);
            await _advisorIdentityDocumentRepository.DeleteRangeAsync(advisorIdentityDocuments);
            var businessUnitDocumentSpec = new GetBusinessUnitDocumentWithDocumentKeySpec(document.DocumentId);
            var businessUnitDocuments = await _businessUnitDocumentRepository.ListAsync(businessUnitDocumentSpec);
            await _businessUnitDocumentRepository.DeleteRangeAsync(businessUnitDocuments);
            var customerDocumentSpec = new GetCustomerDocumentWithDocumentKeySpec(document.DocumentId);
            var customerDocuments = await _customerDocumentRepository.ListAsync(customerDocumentSpec);
            await _customerDocumentRepository.DeleteRangeAsync(customerDocuments);
            var messageDocumentSpec = new GetMessageDocumentWithDocumentKeySpec(document.DocumentId);
            var messageDocuments = await _messageDocumentRepository.ListAsync(messageDocumentSpec);
            await _messageDocumentRepository.DeleteRangeAsync(messageDocuments);
            var templateDocumentSpec = new GetTemplateDocumentWithDocumentKeySpec(document.DocumentId);
            var templateDocuments = await _templateDocumentRepository.ListAsync(templateDocumentSpec);
            await _templateDocumentRepository.DeleteRangeAsync(templateDocuments);
            var voiceNoteDocumentSpec = new GetVoiceNoteDocumentWithDocumentKeySpec(document.DocumentId);
            var voiceNoteDocuments = await _voiceNoteDocumentRepository.ListAsync(voiceNoteDocumentSpec);
            await _voiceNoteDocumentRepository.DeleteRangeAsync(voiceNoteDocuments);

            var documentDeletedEvent = new DocumentDeletedEvent(document, "Mongo-History");
            _messagePublisher.Publish(documentDeletedEvent);

            await _repository.DeleteAsync(document);

            return Ok(response);
        }
    }
}