using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class DeleteCustomerPurchaseResponse : BaseResponse
    {
        public DeleteCustomerPurchaseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerPurchaseResponse()
        {
        }
    }
}