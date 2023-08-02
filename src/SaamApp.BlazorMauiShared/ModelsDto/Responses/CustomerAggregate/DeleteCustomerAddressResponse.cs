using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAddress
{
    public class DeleteCustomerAddressResponse : BaseResponse
    {
        public DeleteCustomerAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerAddressResponse()
        {
        }
    }
}