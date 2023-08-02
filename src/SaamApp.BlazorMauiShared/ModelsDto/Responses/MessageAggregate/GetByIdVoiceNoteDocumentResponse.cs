using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.VoiceNoteDocument
{
    public class GetByIdVoiceNoteDocumentResponse : BaseResponse
    {
        public GetByIdVoiceNoteDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdVoiceNoteDocumentResponse()
        {
        }

        public VoiceNoteDocumentDto VoiceNoteDocument { get; set; } = new();
    }
}