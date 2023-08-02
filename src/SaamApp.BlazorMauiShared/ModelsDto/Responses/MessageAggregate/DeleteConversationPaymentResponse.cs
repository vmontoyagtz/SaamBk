using System;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class DeleteConversationPaymentResponse : BaseResponse
    {
        public DeleteConversationPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteConversationPaymentResponse()
        {
        }
    }
}