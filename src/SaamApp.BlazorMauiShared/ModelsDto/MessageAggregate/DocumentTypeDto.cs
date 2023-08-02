using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class DocumentTypeDto
    {
        public DocumentTypeDto() { } // AutoMapper required

        public DocumentTypeDto(Guid documentTypeId, string documentTypeName, string? documentTypeDescription,
            Guid tenantId)
        {
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            DocumentTypeName = Guard.Against.NullOrWhiteSpace(documentTypeName, nameof(documentTypeName));
            DocumentTypeDescription = documentTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid DocumentTypeId { get; set; }

        [Required(ErrorMessage = "Document Type Name is required")]
        [MaxLength(100)]
        public string DocumentTypeName { get; set; }

        [MaxLength(100)] public string? DocumentTypeDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AdvisorDocumentDto> AdvisorDocuments { get; set; } = new();
        public List<AdvisorIdentityDocumentDto> AdvisorIdentityDocuments { get; set; } = new();
        public List<BusinessUnitDocumentDto> BusinessUnitDocuments { get; set; } = new();
        public List<CustomerDocumentDto> CustomerDocuments { get; set; } = new();
        public List<MessageDocumentDto> MessageDocuments { get; set; } = new();
        public List<TemplateDocumentDto> TemplateDocuments { get; set; } = new();
        public List<VoiceNoteDocumentDto> VoiceNoteDocuments { get; set; } = new();
    }
}