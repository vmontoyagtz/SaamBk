using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class CreateEmployeeResponse : BaseResponse
    {
        public CreateEmployeeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateEmployeeResponse()
        {
        }

        public EmployeeDto Employee { get; set; } = new();
    }
}