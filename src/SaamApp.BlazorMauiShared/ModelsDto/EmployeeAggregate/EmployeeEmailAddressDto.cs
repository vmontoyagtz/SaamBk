using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class EmployeeEmailAddressDto
    {
        public EmployeeEmailAddressDto() { } // AutoMapper required

        public EmployeeEmailAddressDto(Guid emailAddressId, Guid emailAddressTypeId, Guid employeeId)
        {
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
        }

        public int RowId { get; set; }

        public EmailAddressDto EmailAddress { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        public Guid EmailAddressId { get; set; }

        public EmailAddressTypeDto EmailAddressType { get; set; }

        [Required(ErrorMessage = "Email Address Type is required")]
        public Guid EmailAddressTypeId { get; set; }

        public EmployeeDto Employee { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public Guid EmployeeId { get; set; }
    }
}