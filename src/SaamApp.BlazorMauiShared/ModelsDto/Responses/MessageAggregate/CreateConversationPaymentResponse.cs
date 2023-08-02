using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class CreateConversationPaymentResponse : BaseResponse
    {
        public CreateConversationPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateConversationPaymentResponse()
        {
        }

        public ConversationPaymentDto ConversationPayment { get; set; } = new();
    }
}