using System;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class DeleteSerfinsaPaymentResponse : BaseResponse
    {
        public DeleteSerfinsaPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteSerfinsaPaymentResponse()
        {
        }
    }
}