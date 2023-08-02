using System;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class GetByRelsIdsConversationPaymentRequest : BaseRequest
    {
        public Guid AdvisorPaymentId { get; set; }
        public Guid ConversationId { get; set; }
    }
}