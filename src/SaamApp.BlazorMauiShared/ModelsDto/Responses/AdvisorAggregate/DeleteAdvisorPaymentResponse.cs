using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class DeleteAdvisorPaymentResponse : BaseResponse
    {
        public DeleteAdvisorPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorPaymentResponse()
        {
        }
    }
}