using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerDocumentDto
    {
        public CustomerDocumentDto() { } // AutoMapper required

        public CustomerDocumentDto(Guid customerId, Guid documentId, Guid documentTypeId)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
        }

        public int RowId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public DocumentDto Document { get; set; }

        [Required(ErrorMessage = "Document is required")]
        public Guid DocumentId { get; set; }

        public DocumentTypeDto DocumentType { get; set; }

        [Required(ErrorMessage = "Document Type is required")]
        public Guid DocumentTypeId { get; set; }
    }
}