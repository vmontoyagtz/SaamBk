using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.VoiceNoteDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.VoiceNoteDocumentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteVoiceNoteDocumentRequest>.WithActionResult<
        DeleteVoiceNoteDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<VoiceNoteDocument> _repository;
        private readonly IRepository<VoiceNoteDocument> _voiceNoteDocumentReadRepository;

        public Delete(IRepository<VoiceNoteDocument> VoiceNoteDocumentRepository,
            IRepository<VoiceNoteDocument> VoiceNoteDocumentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = VoiceNoteDocumentRepository;
            _voiceNoteDocumentReadRepository = VoiceNoteDocumentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/voiceNoteDocuments/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an VoiceNoteDocument",
            Description = "Deletes an VoiceNoteDocument",
            OperationId = "voiceNoteDocuments.delete",
            Tags = new[] { "VoiceNoteDocumentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteVoiceNoteDocumentResponse>> HandleAsync(
            [FromRoute] DeleteVoiceNoteDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteVoiceNoteDocumentResponse(request.CorrelationId());

            var voiceNoteDocument = await _voiceNoteDocumentReadRepository.GetByIdAsync(request.RowId);

            if (voiceNoteDocument == null)
            {
                return NotFound();
            }


            var voiceNoteDocumentDeletedEvent = new VoiceNoteDocumentDeletedEvent(voiceNoteDocument, "Mongo-History");
            _messagePublisher.Publish(voiceNoteDocumentDeletedEvent);

            await _repository.DeleteAsync(voiceNoteDocument);

            return Ok(response);
        }
    }
}