using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class PhoneNumberTypeDto
    {
        public PhoneNumberTypeDto() { } // AutoMapper required

        public PhoneNumberTypeDto(Guid phoneNumberTypeId, string phoneNumberTypeName, string? description,
            Guid tenantId)
        {
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
            PhoneNumberTypeName = Guard.Against.NullOrWhiteSpace(phoneNumberTypeName, nameof(phoneNumberTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid PhoneNumberTypeId { get; set; }

        [Required(ErrorMessage = "Phone Number Type Name is required")]
        [MaxLength(100)]
        public string PhoneNumberTypeName { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AdvisorPhoneNumberDto> AdvisorPhoneNumbers { get; set; } = new();
        public List<BusinessUnitPhoneNumberDto> BusinessUnitPhoneNumbers { get; set; } = new();
        public List<CustomerPhoneNumberDto> CustomerPhoneNumbers { get; set; } = new();
        public List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();
    }
}