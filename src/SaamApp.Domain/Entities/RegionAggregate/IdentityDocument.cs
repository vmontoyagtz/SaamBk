using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class IdentityDocument : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorIdentityDocument> _advisorIdentityDocuments = new();


        private IdentityDocument() { } // EF required

        //[SetsRequiredMembers]
        public IdentityDocument(Guid identityDocumentId, Guid countryId, string identityDocumentName,
            string identityDocumentNumber, string? identityDocumentDescription, Guid tenantId)
        {
            IdentityDocumentId = Guard.Against.NullOrEmpty(identityDocumentId, nameof(identityDocumentId));
            CountryId = Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            IdentityDocumentName = Guard.Against.NullOrWhiteSpace(identityDocumentName, nameof(identityDocumentName));
            IdentityDocumentNumber =
                Guard.Against.NullOrWhiteSpace(identityDocumentNumber, nameof(identityDocumentNumber));
            IdentityDocumentDescription = identityDocumentDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid IdentityDocumentId { get; private set; }

        public string IdentityDocumentName { get; private set; }

        public string IdentityDocumentNumber { get; private set; }

        public string? IdentityDocumentDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Country Country { get; private set; }

        public Guid CountryId { get; private set; }
        public IEnumerable<AdvisorIdentityDocument> AdvisorIdentityDocuments => _advisorIdentityDocuments.AsReadOnly();

        public void SetIdentityDocumentName(string identityDocumentName)
        {
            IdentityDocumentName = Guard.Against.NullOrEmpty(identityDocumentName, nameof(identityDocumentName));
        }

        public void SetIdentityDocumentNumber(string identityDocumentNumber)
        {
            IdentityDocumentNumber = Guard.Against.NullOrEmpty(identityDocumentNumber, nameof(identityDocumentNumber));
        }

        public void SetIdentityDocumentDescription(string identityDocumentDescription)
        {
            IdentityDocumentDescription = identityDocumentDescription;
        }
    }
}