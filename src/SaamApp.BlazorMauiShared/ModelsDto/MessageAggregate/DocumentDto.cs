using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class DocumentDto
    {
        public DocumentDto() { } // AutoMapper required

        public DocumentDto(Guid documentId, string documentUri, string documentToken, string documentSecuredUrl,
            string documentTitle, string documentDescription, Guid tenantId)
        {
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentUri = Guard.Against.NullOrWhiteSpace(documentUri, nameof(documentUri));
            DocumentToken = Guard.Against.NullOrWhiteSpace(documentToken, nameof(documentToken));
            DocumentSecuredUrl = Guard.Against.NullOrWhiteSpace(documentSecuredUrl, nameof(documentSecuredUrl));
            DocumentTitle = Guard.Against.NullOrWhiteSpace(documentTitle, nameof(documentTitle));
            DocumentDescription = Guard.Against.NullOrWhiteSpace(documentDescription, nameof(documentDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid DocumentId { get; set; }

        [Required(ErrorMessage = "Document Uri is required")]
        [MaxLength(100)]
        public string DocumentUri { get; set; }

        [Required(ErrorMessage = "Document Token is required")]
        [MaxLength(100)]
        public string DocumentToken { get; set; }

        [Required(ErrorMessage = "Document Secured Url is required")]
        [MaxLength(100)]
        public string DocumentSecuredUrl { get; set; }

        [Required(ErrorMessage = "Document Title is required")]
        [MaxLength(100)]
        public string DocumentTitle { get; set; }

        [Required(ErrorMessage = "Document Description is required")]
        [MaxLength(100)]
        public string DocumentDescription { get; set; }

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