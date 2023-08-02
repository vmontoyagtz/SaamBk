using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class DeleteCustomerEmailAddressResponse : BaseResponse
    {
        public DeleteCustomerEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerEmailAddressResponse()
        {
        }
    }
}