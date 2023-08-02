using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorAddressDto
    {
        public AdvisorAddressDto() { } // AutoMapper required

        public AdvisorAddressDto(Guid addressId, Guid addressTypeId, Guid advisorId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
        }

        public int RowId { get; set; }

        public AddressDto Address { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public Guid AddressId { get; set; }

        public AddressTypeDto AddressType { get; set; }

        [Required(ErrorMessage = "Address Type is required")]
        public Guid AddressTypeId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }
    }
}