using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.VoiceNoteDocument
{
    public class UpdateVoiceNoteDocumentResponse : BaseResponse
    {
        public UpdateVoiceNoteDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateVoiceNoteDocumentResponse()
        {
        }

        public VoiceNoteDocumentDto VoiceNoteDocument { get; set; } = new();
    }
}