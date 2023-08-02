using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber
{
    public class DeleteEmployeePhoneNumberResponse : BaseResponse
    {
        public DeleteEmployeePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteEmployeePhoneNumberResponse()
        {
        }
    }
}