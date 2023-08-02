using System;

namespace SaamApp.BlazorMauiShared.Models.Employee
{
    public class DeleteEmployeeResponse : BaseResponse
    {
        public DeleteEmployeeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteEmployeeResponse()
        {
        }
    }
}