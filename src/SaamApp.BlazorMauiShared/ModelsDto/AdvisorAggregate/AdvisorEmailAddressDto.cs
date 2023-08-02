using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorEmailAddressDto
    {
        public AdvisorEmailAddressDto() { } // AutoMapper required

        public AdvisorEmailAddressDto(Guid advisorId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
        }

        public int RowId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public EmailAddressDto EmailAddress { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        public Guid EmailAddressId { get; set; }

        public EmailAddressTypeDto EmailAddressType { get; set; }

        [Required(ErrorMessage = "Email Address Type is required")]
        public Guid EmailAddressTypeId { get; set; }
    }
}