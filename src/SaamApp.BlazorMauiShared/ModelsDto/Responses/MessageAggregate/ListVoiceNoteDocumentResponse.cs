using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.VoiceNoteDocument
{
    public class ListVoiceNoteDocumentResponse : BaseResponse
    {
        public ListVoiceNoteDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListVoiceNoteDocumentResponse()
        {
        }

        public List<VoiceNoteDocumentDto> VoiceNoteDocuments { get; set; } = new();

        public int Count { get; set; }
    }
}