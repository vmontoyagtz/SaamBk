using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Document : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorDocument> _advisorDocuments = new();

        private readonly List<AdvisorIdentityDocument> _advisorIdentityDocuments = new();

        private readonly List<BusinessUnitDocument> _businessUnitDocuments = new();

        private readonly List<CustomerDocument> _customerDocuments = new();

        private readonly List<MessageDocument> _messageDocuments = new();

        private readonly List<TemplateDocument> _templateDocuments = new();

        private readonly List<VoiceNoteDocument> _voiceNoteDocuments = new();


        private Document() { } // EF required

        //[SetsRequiredMembers]
        public Document(Guid documentId, string documentUri, string documentToken, string documentSecuredUrl,
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

        [Key] public Guid DocumentId { get; private set; }

        public string DocumentUri { get; private set; }

        public string DocumentToken { get; private set; }

        public string DocumentSecuredUrl { get; private set; }

        public string DocumentTitle { get; private set; }

        public string DocumentDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<AdvisorDocument> AdvisorDocuments => _advisorDocuments.AsReadOnly();
        public IEnumerable<AdvisorIdentityDocument> AdvisorIdentityDocuments => _advisorIdentityDocuments.AsReadOnly();
        public IEnumerable<BusinessUnitDocument> BusinessUnitDocuments => _businessUnitDocuments.AsReadOnly();
        public IEnumerable<CustomerDocument> CustomerDocuments => _customerDocuments.AsReadOnly();
        public IEnumerable<MessageDocument> MessageDocuments => _messageDocuments.AsReadOnly();
        public IEnumerable<TemplateDocument> TemplateDocuments => _templateDocuments.AsReadOnly();
        public IEnumerable<VoiceNoteDocument> VoiceNoteDocuments => _voiceNoteDocuments.AsReadOnly();

        public void SetDocumentUri(string documentUri)
        {
            DocumentUri = Guard.Against.NullOrEmpty(documentUri, nameof(documentUri));
        }

        public void SetDocumentToken(string documentToken)
        {
            DocumentToken = Guard.Against.NullOrEmpty(documentToken, nameof(documentToken));
        }

        public void SetDocumentSecuredUrl(string documentSecuredUrl)
        {
            DocumentSecuredUrl = Guard.Against.NullOrEmpty(documentSecuredUrl, nameof(documentSecuredUrl));
        }

        public void SetDocumentTitle(string documentTitle)
        {
            DocumentTitle = Guard.Against.NullOrEmpty(documentTitle, nameof(documentTitle));
        }

        public void SetDocumentDescription(string documentDescription)
        {
            DocumentDescription = Guard.Against.NullOrEmpty(documentDescription, nameof(documentDescription));
        }
    }
}