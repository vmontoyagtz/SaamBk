using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorDocumentDto
    {
        public AdvisorDocumentDto() { } // AutoMapper required

        public AdvisorDocumentDto(Guid advisorId, Guid documentId, Guid documentTypeId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
        }

        public int RowId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public DocumentDto Document { get; set; }

        [Required(ErrorMessage = "Document is required")]
        public Guid DocumentId { get; set; }

        public DocumentTypeDto DocumentType { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        public Guid DocumentTypeId { get; set; }
    }
}