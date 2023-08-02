using System;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class DeleteCustomerResponse : BaseResponse
    {
        public DeleteCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerResponse()
        {
        }
    }
}