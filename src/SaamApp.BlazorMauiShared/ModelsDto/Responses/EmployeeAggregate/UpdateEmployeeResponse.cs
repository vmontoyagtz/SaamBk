using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class UpdateEmployeeResponse : BaseResponse
    {
        public UpdateEmployeeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateEmployeeResponse()
        {
        }

        public EmployeeDto Employee { get; set; } = new();
    }
}