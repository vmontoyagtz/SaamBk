using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class TemplateDocument : BaseEntityEv<int>, IAggregateRoot
    {
        private TemplateDocument() { } // EF required

        //[SetsRequiredMembers]
        public TemplateDocument(Guid documentId, Guid documentTypeId, Guid templateId, Guid tenantId)
        {
            DocumentId = Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            TemplateId = Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public int RowId { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Document Document { get; private set; }

        public Guid DocumentId { get; private set; }

        public virtual DocumentType DocumentType { get; private set; }

        public Guid DocumentTypeId { get; private set; }

        public virtual Template Template { get; private set; }

        public Guid TemplateId { get; private set; }
    }
}