using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class DeletePaymentMethodResponse : BaseResponse
    {
        public DeletePaymentMethodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeletePaymentMethodResponse()
        {
        }
    }
}