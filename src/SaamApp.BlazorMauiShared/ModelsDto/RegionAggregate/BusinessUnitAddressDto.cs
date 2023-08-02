using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BusinessUnitAddressDto
    {
        public BusinessUnitAddressDto() { } // AutoMapper required

        public BusinessUnitAddressDto(Guid addressId, Guid addressTypeId, Guid businessUnitId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
        }

        public int RowId { get; set; }

        public AddressDto Address { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public Guid AddressId { get; set; }

        public AddressTypeDto AddressType { get; set; }

        [Required(ErrorMessage = "Address Type is required")]
        public Guid AddressTypeId { get; set; }

        public BusinessUnitDto BusinessUnit { get; set; }

        [Required(ErrorMessage = "Business Unit is required")]
        public Guid BusinessUnitId { get; set; }
    }
}