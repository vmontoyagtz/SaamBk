using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class EmailAddressDto
    {
        public EmailAddressDto() { } // AutoMapper required

        public EmailAddressDto(Guid emailAddressId, string emailAddressString)
        {
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressString = Guard.Against.NullOrWhiteSpace(emailAddressString, nameof(emailAddressString));
        }

        public Guid EmailAddressId { get; set; }

        [Required(ErrorMessage = "Email Address String is required")]
        [MaxLength(100)]
        public string EmailAddressString { get; set; }

        public List<AdvisorEmailAddressDto> AdvisorEmailAddresses { get; set; } = new();
        public List<BusinessUnitEmailAddressDto> BusinessUnitEmailAddresses { get; set; } = new();
        public List<CustomerEmailAddressDto> CustomerEmailAddresses { get; set; } = new();
        public List<EmployeeEmailAddressDto> EmployeeEmailAddresses { get; set; } = new();
    }
}