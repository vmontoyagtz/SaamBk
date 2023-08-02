using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TemplateDocumentDto
    {
        public TemplateDocumentDto() { } // AutoMapper required

        public TemplateDocumentDto(Guid documentId, Guid documentTypeId, Guid templateId, Guid tenantId)
        {
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            TemplateId = Guard.Against.NullOrEmpty(templateId, nameof(templateId));
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

        public TemplateDto Template { get; set; }

        [Required(ErrorMessage = "Template is required")]
        public Guid TemplateId { get; set; }
    }
}