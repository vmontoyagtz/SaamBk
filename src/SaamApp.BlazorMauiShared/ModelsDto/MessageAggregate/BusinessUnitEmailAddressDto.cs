using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BusinessUnitEmailAddressDto
    {
        public BusinessUnitEmailAddressDto() { } // AutoMapper required

        public BusinessUnitEmailAddressDto(Guid businessUnitId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
        }

        public int RowId { get; set; }

        public BusinessUnitDto BusinessUnit { get; set; }

        [Required(ErrorMessage = "Business Unit is required")]
        public Guid BusinessUnitId { get; set; }

        public EmailAddressDto EmailAddress { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        public Guid EmailAddressId { get; set; }

        public EmailAddressTypeDto EmailAddressType { get; set; }

        [Required(ErrorMessage = "Email Address Type is required")]
        public Guid EmailAddressTypeId { get; set; }
    }
}