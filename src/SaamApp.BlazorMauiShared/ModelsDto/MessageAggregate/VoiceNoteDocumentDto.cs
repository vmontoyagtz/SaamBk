using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class VoiceNoteDocumentDto
    {
        public VoiceNoteDocumentDto() { } // AutoMapper required

        public VoiceNoteDocumentDto(Guid documentId, Guid documentTypeId, Guid messageId, Guid tenantId)
        {
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            MessageId = Guard.Against.NullOrEmpty(messageId, nameof(messageId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public DocumentDto Document { get; set; }

        [Required(ErrorMessage = "Document is required")]
        public Guid DocumentId { get; set; }

        public DocumentTypeDto DocumentType { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        public Guid DocumentTypeId { get; set; }

        public MessageDto Message { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public Guid MessageId { get; set; }
    }
}