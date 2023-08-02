using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class EmailAddressTypeDto
    {
        public EmailAddressTypeDto() { } // AutoMapper required

        public EmailAddressTypeDto(Guid emailAddressTypeId, string emailAddressTypeName, string? description,
            Guid tenantId)
        {
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            EmailAddressTypeName = Guard.Against.NullOrWhiteSpace(emailAddressTypeName, nameof(emailAddressTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid EmailAddressTypeId { get; set; }

        [Required(ErrorMessage = "Email Address Type Name is required")]
        [MaxLength(100)]
        public string EmailAddressTypeName { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AdvisorEmailAddressDto> AdvisorEmailAddresses { get; set; } = new();
        public List<BusinessUnitEmailAddressDto> BusinessUnitEmailAddresses { get; set; } = new();
        public List<CustomerEmailAddressDto> CustomerEmailAddresses { get; set; } = new();
        public List<EmployeeEmailAddressDto> EmployeeEmailAddresses { get; set; } = new();
    }
}