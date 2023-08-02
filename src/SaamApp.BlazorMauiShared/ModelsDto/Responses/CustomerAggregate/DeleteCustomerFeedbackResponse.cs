using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class DeleteCustomerFeedbackResponse : BaseResponse
    {
        public DeleteCustomerFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerFeedbackResponse()
        {
        }
    }
}