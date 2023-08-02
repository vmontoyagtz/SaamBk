using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AddressDto
    {
        public AddressDto() { } // AutoMapper required

        public AddressDto(Guid addressId, Guid cityId, Guid countryId, Guid regionId, Guid stateId, string addressStr,
            string zipCode, Guid tenantId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            CityId = Guard.Against.NullOrEmpty(cityId, nameof(cityId));
            CountryId = Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            StateId = Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            AddressStr = Guard.Against.NullOrWhiteSpace(addressStr, nameof(addressStr));
            ZipCode = Guard.Against.NullOrWhiteSpace(zipCode, nameof(zipCode));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AddressId { get; set; }

        [Required(ErrorMessage = "Address Str is required")]
        [MaxLength(100)]
        public string AddressStr { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [MaxLength(100)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public CityDto City { get; set; }

        [Required(ErrorMessage = "City is required")]
        public Guid CityId { get; set; }

        public CountryDto Country { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public Guid CountryId { get; set; }

        public RegionDto Region { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public Guid RegionId { get; set; }

        public StateDto State { get; set; }

        [Required(ErrorMessage = "State is required")]
        public Guid StateId { get; set; }

        public List<AdvisorAddressDto> AdvisorAddresses { get; set; } = new();
        public List<BusinessUnitAddressDto> BusinessUnitAddresses { get; set; } = new();
        public List<CustomerAddressDto> CustomerAddresses { get; set; } = new();
        public List<EmployeeAddressDto> EmployeeAddresses { get; set; } = new();
    }
}