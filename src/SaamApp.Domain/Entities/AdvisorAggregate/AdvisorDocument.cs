using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorDocument : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorDocument() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorDocument(Guid advisorId, Guid documentId, Guid documentTypeId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual Document Document { get; private set; }

        public Guid DocumentId { get; private set; }

        public virtual DocumentType DocumentType { get; private set; }

        public Guid DocumentTypeId { get; private set; }
    }
}