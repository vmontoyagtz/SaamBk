using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class UpdateEmployeeRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? EmployeeJobTitle { get; set; }
        public DateTime? EmployeeHireDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateEmployeeRequest FromDto(EmployeeDto employeeDto)
        {
            return new UpdateEmployeeRequest
            {
                EmployeeId = employeeDto.EmployeeId,
                EmployeeFirstName = employeeDto.EmployeeFirstName,
                EmployeeLastName = employeeDto.EmployeeLastName,
                EmployeeNumber = employeeDto.EmployeeNumber,
                EmployeeJobTitle = employeeDto.EmployeeJobTitle,
                EmployeeHireDate = employeeDto.EmployeeHireDate,
                IsActive = employeeDto.IsActive,
                CreatedAt = employeeDto.CreatedAt,
                CreatedBy = employeeDto.CreatedBy,
                UpdatedAt = employeeDto.UpdatedAt,
                UpdatedBy = employeeDto.UpdatedBy,
                IsDeleted = employeeDto.IsDeleted,
                TenantId = employeeDto.TenantId
            };
        }
    }
}