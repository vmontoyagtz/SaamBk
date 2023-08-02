using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class DeletePaymentFrequencyResponse : BaseResponse
    {
        public DeletePaymentFrequencyResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeletePaymentFrequencyResponse()
        {
        }
    }
}