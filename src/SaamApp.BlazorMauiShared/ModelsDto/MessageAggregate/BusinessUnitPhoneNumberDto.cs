using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BusinessUnitPhoneNumberDto
    {
        public BusinessUnitPhoneNumberDto() { } // AutoMapper required

        public BusinessUnitPhoneNumberDto(Guid businessUnitId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        public int RowId { get; set; }

        public BusinessUnitDto BusinessUnit { get; set; }

        [Required(ErrorMessage = "Business Unit is required")]
        public Guid BusinessUnitId { get; set; }

        public PhoneNumberDto PhoneNumber { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public Guid PhoneNumberId { get; set; }

        public PhoneNumberTypeDto PhoneNumberType { get; set; }

        [Required(ErrorMessage = "Phone Number Type is required")]
        public Guid PhoneNumberTypeId { get; set; }
    }
}