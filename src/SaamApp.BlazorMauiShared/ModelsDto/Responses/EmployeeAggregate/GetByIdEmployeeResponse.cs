using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class GetByIdEmployeeResponse : BaseResponse
    {
        public GetByIdEmployeeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdEmployeeResponse()
        {
        }

        public EmployeeDto Employee { get; set; } = new();
    }
}