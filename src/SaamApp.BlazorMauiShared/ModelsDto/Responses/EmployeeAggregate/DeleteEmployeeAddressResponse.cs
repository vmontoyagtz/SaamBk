using System;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class DeleteEmployeeAddressResponse : BaseResponse
    {
        public DeleteEmployeeAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteEmployeeAddressResponse()
        {
        }
    }
}