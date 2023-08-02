using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.VoiceNoteDocument
{
    public class CreateVoiceNoteDocumentResponse : BaseResponse
    {
        public CreateVoiceNoteDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateVoiceNoteDocumentResponse()
        {
        }

        public VoiceNoteDocumentDto VoiceNoteDocument { get; set; } = new();
    }
}