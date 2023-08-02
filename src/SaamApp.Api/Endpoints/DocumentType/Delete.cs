using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DocumentType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DocumentTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteDocumentTypeRequest>.WithActionResult<
        DeleteDocumentTypeResponse>
    {
        private readonly IRepository<AdvisorDocument> _advisorDocumentRepository;
        private readonly IRepository<AdvisorIdentityDocument> _advisorIdentityDocumentRepository;
        private readonly IRepository<BusinessUnitDocument> _businessUnitDocumentRepository;
        private readonly IRepository<CustomerDocument> _customerDocumentRepository;
        private readonly IRepository<DocumentType> _documentTypeReadRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<MessageDocument> _messageDocumentRepository;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DocumentType> _repository;
        private readonly IRepository<TemplateDocument> _templateDocumentRepository;
        private readonly IRepository<VoiceNoteDocument> _voiceNoteDocumentRepository;

        public Delete(IRepository<DocumentType> DocumentTypeRepository,
            IRepository<DocumentType> DocumentTypeReadRepository,
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
            _repository = DocumentTypeRepository;
            _documentTypeReadRepository = DocumentTypeReadRepository;
            _advisorDocumentRepository = advisorDocumentRepository;
            _advisorIdentityDocumentRepository = advisorIdentityDocumentRepository;
            _businessUnitDocumentRepository = businessUnitDocumentRepository;
            _customerDocumentRepository = customerDocumentRepository;
            _messageDocumentRepository = messageDocumentRepository;
            _templateDocumentRepository = templateDocumentRepository;
            _voiceNoteDocumentRepository = voiceNoteDocumentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/documentTypes/{DocumentTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an DocumentType",
            Description = "Deletes an DocumentType",
            OperationId = "documentTypes.delete",
            Tags = new[] { "DocumentTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteDocumentTypeResponse>> HandleAsync(
            [FromRoute] DeleteDocumentTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteDocumentTypeResponse(request.CorrelationId());

            var documentType = await _documentTypeReadRepository.GetByIdAsync(request.DocumentTypeId);

            if (documentType == null)
            {
                return NotFound();
            }

            var advisorDocumentSpec = new GetAdvisorDocumentWithDocumentTypeKeySpec(documentType.DocumentTypeId);
            var advisorDocuments = await _advisorDocumentRepository.ListAsync(advisorDocumentSpec);
            await _advisorDocumentRepository.DeleteRangeAsync(advisorDocuments);
            var advisorIdentityDocumentSpec =
                new GetAdvisorIdentityDocumentWithDocumentTypeKeySpec(documentType.DocumentTypeId);
            var advisorIdentityDocuments =
                await _advisorIdentityDocumentRepository.ListAsync(advisorIdentityDocumentSpec);
            await _advisorIdentityDocumentRepository.DeleteRangeAsync(advisorIdentityDocuments);
            var businessUnitDocumentSpec =
                new GetBusinessUnitDocumentWithDocumentTypeKeySpec(documentType.DocumentTypeId);
            var businessUnitDocuments = await _businessUnitDocumentRepository.ListAsync(businessUnitDocumentSpec);
            await _businessUnitDocumentRepository.DeleteRangeAsync(businessUnitDocuments);
            var customerDocumentSpec = new GetCustomerDocumentWithDocumentTypeKeySpec(documentType.DocumentTypeId);
            var customerDocuments = await _customerDocumentRepository.ListAsync(customerDocumentSpec);
            await _customerDocumentRepository.DeleteRangeAsync(customerDocuments);
            var messageDocumentSpec = new GetMessageDocumentWithDocumentTypeKeySpec(documentType.DocumentTypeId);
            var messageDocuments = await _messageDocumentRepository.ListAsync(messageDocumentSpec);
            await _messageDocumentRepository.DeleteRangeAsync(messageDocuments);
            var templateDocumentSpec = new GetTemplateDocumentWithDocumentTypeKeySpec(documentType.DocumentTypeId);
            var templateDocuments = await _templateDocumentRepository.ListAsync(templateDocumentSpec);
            await _templateDocumentRepository.DeleteRangeAsync(templateDocuments);
            var voiceNoteDocumentSpec = new GetVoiceNoteDocumentWithDocumentTypeKeySpec(documentType.DocumentTypeId);
            var voiceNoteDocuments = await _voiceNoteDocumentRepository.ListAsync(voiceNoteDocumentSpec);
            await _voiceNoteDocumentRepository.DeleteRangeAsync(voiceNoteDocuments);

            var documentTypeDeletedEvent = new DocumentTypeDeletedEvent(documentType, "Mongo-History");
            _messagePublisher.Publish(documentTypeDeletedEvent);

            await _repository.DeleteAsync(documentType);

            return Ok(response);
        }
    }
}