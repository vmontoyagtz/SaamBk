using System;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class DeleteEmployeeRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
    }
}