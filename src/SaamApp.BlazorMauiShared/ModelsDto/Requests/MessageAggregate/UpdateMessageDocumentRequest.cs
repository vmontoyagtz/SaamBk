using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.MessageDocument
{
    public class UpdateMessageDocumentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public Guid MessageId { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateMessageDocumentRequest FromDto(MessageDocumentDto messageDocumentDto)
        {
            return new UpdateMessageDocumentRequest
            {
                RowId = messageDocumentDto.RowId,
                DocumentId = messageDocumentDto.DocumentId,
                DocumentTypeId = messageDocumentDto.DocumentTypeId,
                MessageId = messageDocumentDto.MessageId,
                TenantId = messageDocumentDto.TenantId
            };
        }
    }
}