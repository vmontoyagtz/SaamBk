using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class IdentityDocumentDto
    {
        public IdentityDocumentDto() { } // AutoMapper required

        public IdentityDocumentDto(Guid identityDocumentId, Guid countryId, string identityDocumentName,
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

        public Guid IdentityDocumentId { get; set; }

        [Required(ErrorMessage = "Identity Document Name is required")]
        [MaxLength(100)]
        public string IdentityDocumentName { get; set; }

        [Required(ErrorMessage = "Identity Document Number is required")]
        [MaxLength(100)]
        public string IdentityDocumentNumber { get; set; }

        [MaxLength(100)] public string? IdentityDocumentDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public CountryDto Country { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public Guid CountryId { get; set; }

        public List<AdvisorIdentityDocumentDto> AdvisorIdentityDocuments { get; set; } = new();
    }
}