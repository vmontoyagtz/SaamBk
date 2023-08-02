using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerPhoneNumberDto
    {
        public CustomerPhoneNumberDto() { } // AutoMapper required

        public CustomerPhoneNumberDto(Guid customerId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        public int RowId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public PhoneNumberDto PhoneNumber { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public Guid PhoneNumberId { get; set; }

        public PhoneNumberTypeDto PhoneNumberType { get; set; }

        [Required(ErrorMessage = "Phone Number Type is required")]
        public Guid PhoneNumberTypeId { get; set; }
    }
}