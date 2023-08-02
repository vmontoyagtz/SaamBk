using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorPhoneNumberDto
    {
        public AdvisorPhoneNumberDto() { } // AutoMapper required

        public AdvisorPhoneNumberDto(Guid advisorId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        public int RowId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public PhoneNumberDto PhoneNumber { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public Guid PhoneNumberId { get; set; }

        public PhoneNumberTypeDto PhoneNumberType { get; set; }

        [Required(ErrorMessage = "Phone Number Type is required")]
        public Guid PhoneNumberTypeId { get; set; }
    }
}