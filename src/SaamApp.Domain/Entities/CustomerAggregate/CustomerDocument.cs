using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerDocument : BaseEntityEv<int>, IAggregateRoot
    {
        private CustomerDocument() { } // EF required

        //[SetsRequiredMembers]
        public CustomerDocument(Guid customerId, Guid documentId, Guid documentTypeId)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual Document Document { get; private set; }

        public Guid DocumentId { get; private set; }

        public virtual DocumentType DocumentType { get; private set; }

        public Guid DocumentTypeId { get; private set; }
    }
}