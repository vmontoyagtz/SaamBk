using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.VoiceNoteDocument
{
    public class UpdateVoiceNoteDocumentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid MessageId { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateVoiceNoteDocumentRequest FromDto(VoiceNoteDocumentDto voiceNoteDocumentDto)
        {
            return new UpdateVoiceNoteDocumentRequest
            {
                RowId = voiceNoteDocumentDto.RowId,
                DocumentId = voiceNoteDocumentDto.DocumentId,
                DocumentTypeId = voiceNoteDocumentDto.DocumentTypeId,
                MessageId = voiceNoteDocumentDto.MessageId,
                TenantId = voiceNoteDocumentDto.TenantId
            };
        }
    }
}