using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class EmployeePhoneNumberDto
    {
        public EmployeePhoneNumberDto() { } // AutoMapper required

        public EmployeePhoneNumberDto(Guid employeeId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        public int RowId { get; set; }

        public EmployeeDto Employee { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public Guid EmployeeId { get; set; }

        public PhoneNumberDto PhoneNumber { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public Guid PhoneNumberId { get; set; }

        public PhoneNumberTypeDto PhoneNumberType { get; set; }

        [Required(ErrorMessage = "Phone Number Type is required")]
        public Guid PhoneNumberTypeId { get; set; }
    }
}