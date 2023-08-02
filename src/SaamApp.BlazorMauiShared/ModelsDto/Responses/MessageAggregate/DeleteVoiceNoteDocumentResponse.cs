using System;

namespace SaamApp.BlazorMauiShared.Models.VoiceNoteDocument
{
    public class DeleteVoiceNoteDocumentResponse : BaseResponse
    {
        public DeleteVoiceNoteDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteVoiceNoteDocumentResponse()
        {
        }
    }
}