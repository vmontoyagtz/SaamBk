using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class DeleteCustomerAccountResponse : BaseResponse
    {
        public DeleteCustomerAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerAccountResponse()
        {
        }
    }
}