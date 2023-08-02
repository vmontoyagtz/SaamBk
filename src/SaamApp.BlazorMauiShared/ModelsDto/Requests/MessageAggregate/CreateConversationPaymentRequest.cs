using System;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class CreateConversationPaymentRequest : BaseRequest
    {
        public Guid ConversationId { get; set; }
        public Guid AdvisorPaymentId { get; set; }
        public bool? ConversationPaymentStage { get; set; }
    }
}