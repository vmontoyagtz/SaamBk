using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber
{
    public class DeleteCustomerPhoneNumberResponse : BaseResponse
    {
        public DeleteCustomerPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerPhoneNumberResponse()
        {
        }
    }
}