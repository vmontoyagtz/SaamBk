using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class ListEmployeeResponse : BaseResponse
    {
        public ListEmployeeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListEmployeeResponse()
        {
        }

        public List<EmployeeDto> Employees { get; set; } = new();

        public int Count { get; set; }
    }
}