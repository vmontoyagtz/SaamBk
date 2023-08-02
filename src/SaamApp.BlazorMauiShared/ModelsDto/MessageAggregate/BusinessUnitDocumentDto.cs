using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BusinessUnitDocumentDto
    {
        public BusinessUnitDocumentDto() { } // AutoMapper required

        public BusinessUnitDocumentDto(Guid businessUnitId, Guid documentId, Guid documentTypeId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
        }

        public int RowId { get; set; }

        public BusinessUnitDto BusinessUnit { get; set; }

        [Required(ErrorMessage = "Business Unit is required")]
        public Guid BusinessUnitId { get; set; }

        public DocumentDto Document { get; set; }

        [Required(ErrorMessage = "Document is required")]
        public Guid DocumentId { get; set; }

        public DocumentTypeDto DocumentType { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        public Guid DocumentTypeId { get; set; }
    }
}