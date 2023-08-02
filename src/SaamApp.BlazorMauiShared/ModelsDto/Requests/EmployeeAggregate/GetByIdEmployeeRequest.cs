using System;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class GetByIdEmployeeRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
    }
}