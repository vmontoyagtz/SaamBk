using System;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class CreateEmployeeRequest : BaseRequest
    {
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
    }
}