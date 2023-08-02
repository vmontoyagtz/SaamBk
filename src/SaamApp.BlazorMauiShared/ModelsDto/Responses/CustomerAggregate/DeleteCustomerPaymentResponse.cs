using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPayment
{
    public class DeleteCustomerPaymentResponse : BaseResponse
    {
        public DeleteCustomerPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerPaymentResponse()
        {
        }
    }
}