using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.VoiceNoteDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.VoiceNoteDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateVoiceNoteDocumentRequest>.WithActionResult<
        CreateVoiceNoteDocumentResponse>
    {
        private readonly IRepository<Document> _documentRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<VoiceNoteDocument> _repository;

        public Create(
            IRepository<VoiceNoteDocument> repository,
            IRepository<Document> documentRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _documentRepository = documentRepository;
        }

        [HttpPost("api/voiceNoteDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new VoiceNoteDocument",
            Description = "Creates a new VoiceNoteDocument",
            OperationId = "voiceNoteDocuments.create",
            Tags = new[] { "VoiceNoteDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateVoiceNoteDocumentResponse>> HandleAsync(
            CreateVoiceNoteDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateVoiceNoteDocumentResponse(request.CorrelationId());

            //var document = await _documentRepository.GetByIdAsync(request.DocumentId);// parent entity

            var newVoiceNoteDocument = new VoiceNoteDocument(
                request.DocumentId,
                request.DocumentTypeId,
                request.MessageId,
                request.TenantId
            );


            await _repository.AddAsync(newVoiceNoteDocument);

            _logger.LogInformation(
                $"VoiceNoteDocument created  with Id {newVoiceNoteDocument.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<VoiceNoteDocumentDto>(newVoiceNoteDocument);

            var voiceNoteDocumentCreatedEvent =
                new VoiceNoteDocumentCreatedEvent(newVoiceNoteDocument, "Mongo-History");
            _messagePublisher.Publish(voiceNoteDocumentCreatedEvent);

            response.VoiceNoteDocument = dto;


            return Ok(response);
        }
    }
}