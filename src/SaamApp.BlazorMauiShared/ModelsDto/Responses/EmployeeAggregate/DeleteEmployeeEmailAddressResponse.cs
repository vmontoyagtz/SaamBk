using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class DeleteEmployeeEmailAddressResponse : BaseResponse
    {
        public DeleteEmployeeEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteEmployeeEmailAddressResponse()
        {
        }
    }
}