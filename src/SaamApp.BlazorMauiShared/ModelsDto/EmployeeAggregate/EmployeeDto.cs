using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class EmployeeDto
    {
        public EmployeeDto() { } // AutoMapper required

        public EmployeeDto(Guid employeeId, string employeeFirstName, string employeeLastName, string? employeeNumber,
            string? employeeJobTitle, DateTime? employeeHireDate, bool? isActive, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            EmployeeId = Guard.Against.NullOrEmpty(employeeId, nameof(employeeId));
            EmployeeFirstName = Guard.Against.NullOrWhiteSpace(employeeFirstName, nameof(employeeFirstName));
            EmployeeLastName = Guard.Against.NullOrWhiteSpace(employeeLastName, nameof(employeeLastName));
            EmployeeNumber = employeeNumber;
            EmployeeJobTitle = employeeJobTitle;
            EmployeeHireDate = employeeHireDate;
            IsActive = isActive;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee First Name is required")]
        [MaxLength(100)]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "Employee Last Name is required")]
        [MaxLength(100)]
        public string EmployeeLastName { get; set; }

        [MaxLength(100)] public string? EmployeeNumber { get; set; }

        [MaxLength(100)] public string? EmployeeJobTitle { get; set; }

        public DateTime? EmployeeHireDate { get; set; }

        public bool? IsActive { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<EmployeeAddressDto> EmployeeAddresses { get; set; } = new();
        public List<EmployeeEmailAddressDto> EmployeeEmailAddresses { get; set; } = new();
        public List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();
    }
}