using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.VoiceNoteDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.VoiceNoteDocumentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateVoiceNoteDocumentRequest>.WithActionResult<
        UpdateVoiceNoteDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<VoiceNoteDocument> _repository;

        public Update(
            IRepository<VoiceNoteDocument> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/voiceNoteDocuments")]
        [SwaggerOperation(
            Summary = "Updates a VoiceNoteDocument",
            Description = "Updates a VoiceNoteDocument",
            OperationId = "voiceNoteDocuments.update",
            Tags = new[] { "VoiceNoteDocumentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateVoiceNoteDocumentResponse>> HandleAsync(
            UpdateVoiceNoteDocumentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateVoiceNoteDocumentResponse(request.CorrelationId());

            var vndondindToUpdate = _mapper.Map<VoiceNoteDocument>(request);

            var voiceNoteDocumentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (voiceNoteDocumentToUpdateTest is null)
            {
                return NotFound();
            }

            //vndondindToUpdate.UpdateDocumentForVoiceNoteDocument(request.DocumentId);
            //vndondindToUpdate.UpdateDocumentTypeForVoiceNoteDocument(request.DocumentTypeId);
            //vndondindToUpdate.UpdateMessageForVoiceNoteDocument(request.MessageId);
            await _repository.UpdateAsync(vndondindToUpdate);

            var voiceNoteDocumentUpdatedEvent = new VoiceNoteDocumentUpdatedEvent(vndondindToUpdate, "Mongo-History");
            _messagePublisher.Publish(voiceNoteDocumentUpdatedEvent);

            var dto = _mapper.Map<VoiceNoteDocumentDto>(vndondindToUpdate);
            response.VoiceNoteDocument = dto;

            return Ok(response);
        }
    }
}