using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class UpdateConversationPaymentResponse : BaseResponse
    {
        public UpdateConversationPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateConversationPaymentResponse()
        {
        }

        public ConversationPaymentDto ConversationPayment { get; set; } = new();
    }
}