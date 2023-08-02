using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorIdentityDocumentDto
    {
        public AdvisorIdentityDocumentDto() { } // AutoMapper required

        public AdvisorIdentityDocumentDto(Guid advisorId, Guid documentId, Guid documentTypeId, Guid identityDocumentId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            IdentityDocumentId = Guard.Against.NullOrEmpty(identityDocumentId, nameof(identityDocumentId));
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

        public IdentityDocumentDto IdentityDocument { get; set; }

        [Required(ErrorMessage = "Identity Document is required")]
        public Guid IdentityDocumentId { get; set; }
    }
}