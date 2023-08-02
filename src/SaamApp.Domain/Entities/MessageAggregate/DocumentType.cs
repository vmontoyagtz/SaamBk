using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class DocumentType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorDocument> _advisorDocuments = new();

        private readonly List<AdvisorIdentityDocument> _advisorIdentityDocuments = new();

        private readonly List<BusinessUnitDocument> _businessUnitDocuments = new();

        private readonly List<CustomerDocument> _customerDocuments = new();

        private readonly List<MessageDocument> _messageDocuments = new();

        private readonly List<TemplateDocument> _templateDocuments = new();

        private readonly List<VoiceNoteDocument> _voiceNoteDocuments = new();


        private DocumentType() { } // EF required

        //[SetsRequiredMembers]
        public DocumentType(Guid documentTypeId, string documentTypeName, string? documentTypeDescription,
            Guid tenantId)
        {
            DocumentTypeId = Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            DocumentTypeName = Guard.Against.NullOrWhiteSpace(documentTypeName, nameof(documentTypeName));
            DocumentTypeDescription = documentTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid DocumentTypeId { get; private set; }

        public string DocumentTypeName { get; private set; }

        public string? DocumentTypeDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AdvisorDocument> AdvisorDocuments => _advisorDocuments.AsReadOnly();
        public IEnumerable<AdvisorIdentityDocument> AdvisorIdentityDocuments => _advisorIdentityDocuments.AsReadOnly();
        public IEnumerable<BusinessUnitDocument> BusinessUnitDocuments => _businessUnitDocuments.AsReadOnly();
        public IEnumerable<CustomerDocument> CustomerDocuments => _customerDocuments.AsReadOnly();
        public IEnumerable<MessageDocument> MessageDocuments => _messageDocuments.AsReadOnly();
        public IEnumerable<TemplateDocument> TemplateDocuments => _templateDocuments.AsReadOnly();
        public IEnumerable<VoiceNoteDocument> VoiceNoteDocuments => _voiceNoteDocuments.AsReadOnly();

        public void SetDocumentTypeName(string documentTypeName)
        {
            DocumentTypeName = Guard.Against.NullOrEmpty(documentTypeName, nameof(documentTypeName));
        }

        public void SetDocumentTypeDescription(string documentTypeDescription)
        {
            DocumentTypeDescription = documentTypeDescription;
        }
    }
}