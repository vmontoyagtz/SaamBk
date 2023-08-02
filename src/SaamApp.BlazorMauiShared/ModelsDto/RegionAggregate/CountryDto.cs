using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CountryDto
    {
        public CountryDto() { } // AutoMapper required

        public CountryDto(Guid countryId, Guid regionId, string countryName, string countryCode, Guid tenantId)
        {
            CountryId = Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            CountryName = Guard.Against.NullOrWhiteSpace(countryName, nameof(countryName));
            CountryCode = Guard.Against.NullOrWhiteSpace(countryCode, nameof(countryCode));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid CountryId { get; set; }

        [Required(ErrorMessage = "Country Name is required")]
        [MaxLength(100)]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Country Code is required")]
        [MaxLength(100)]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public RegionDto Region { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public Guid RegionId { get; set; }

        public List<AddressDto> Addresses { get; set; } = new();
        public List<IdentityDocumentDto> IdentityDocuments { get; set; } = new();
        public List<StateDto> States { get; set; } = new();
    }
}