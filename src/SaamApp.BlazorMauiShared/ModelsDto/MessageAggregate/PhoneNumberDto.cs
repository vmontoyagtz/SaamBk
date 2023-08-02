using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class PhoneNumberDto
    {
        public PhoneNumberDto() { } // AutoMapper required

        public PhoneNumberDto(Guid phoneNumberId, string phoneNumberString)
        {
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberString = Guard.Against.NullOrWhiteSpace(phoneNumberString, nameof(phoneNumberString));
        }

        public Guid PhoneNumberId { get; set; }

        [Required(ErrorMessage = "Phone Number String is required")]
        [MaxLength(100)]
        public string PhoneNumberString { get; set; }

        public List<AdvisorPhoneNumberDto> AdvisorPhoneNumbers { get; set; } = new();
        public List<BusinessUnitPhoneNumberDto> BusinessUnitPhoneNumbers { get; set; } = new();
        public List<CustomerPhoneNumberDto> CustomerPhoneNumbers { get; set; } = new();
        public List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();
    }
}