using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class EmployeeAddressDto
    {
        public EmployeeAddressDto() { } // AutoMapper required

        public EmployeeAddressDto(Guid addressId, Guid addressTypeId, Guid employeeId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
        }

        public int RowId { get; set; }

        public AddressDto Address { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public Guid AddressId { get; set; }

        public AddressTypeDto AddressType { get; set; }

        [Required(ErrorMessage = "Address Type is required")]
        public Guid AddressTypeId { get; set; }

        public EmployeeDto Employee { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public Guid EmployeeId { get; set; }
    }
}