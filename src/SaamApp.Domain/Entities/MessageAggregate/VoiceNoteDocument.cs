using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class VoiceNoteDocument : BaseEntityEv<int>, IAggregateRoot
    {
        private VoiceNoteDocument() { } // EF required

        //[SetsRequiredMembers]
        public VoiceNoteDocument(Guid documentId, Guid documentTypeId, Guid messageId, Guid tenantId)
        {
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            MessageId = Guard.Against.NullOrEmpty(messageId, nameof(messageId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public int RowId { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Document Document { get; private set; }

        public Guid DocumentId { get; private set; }

        public virtual DocumentType DocumentType { get; private set; }

        public Guid DocumentTypeId { get; private set; }

        public virtual Message Message { get; private set; }

        public Guid MessageId { get; private set; }
    }
}