using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerEmailAddressDto
    {
        public CustomerEmailAddressDto() { } // AutoMapper required

        public CustomerEmailAddressDto(Guid customerId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
        }

        public int RowId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public EmailAddressDto EmailAddress { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        public Guid EmailAddressId { get; set; }

        public EmailAddressTypeDto EmailAddressType { get; set; }

        [Required(ErrorMessage = "Email Address Type is required")]
        public Guid EmailAddressTypeId { get; set; }
    }
}