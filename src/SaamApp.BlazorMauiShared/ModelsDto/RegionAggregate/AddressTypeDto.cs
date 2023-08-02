using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AddressTypeDto
    {
        public AddressTypeDto() { } // AutoMapper required

        public AddressTypeDto(Guid addressTypeId, string addressTypeName, string? description, Guid tenantId)
        {
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            AddressTypeName = Guard.Against.NullOrWhiteSpace(addressTypeName, nameof(addressTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AddressTypeId { get; set; }

        [Required(ErrorMessage = "Address Type Name is required")]
        [MaxLength(100)]
        public string AddressTypeName { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AdvisorAddressDto> AdvisorAddresses { get; set; } = new();
        public List<BusinessUnitAddressDto> BusinessUnitAddresses { get; set; } = new();
        public List<CustomerAddressDto> CustomerAddresses { get; set; } = new();
        public List<EmployeeAddressDto> EmployeeAddresses { get; set; } = new();
    }
}