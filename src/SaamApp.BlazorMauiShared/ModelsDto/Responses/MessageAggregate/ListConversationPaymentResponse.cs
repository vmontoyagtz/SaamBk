using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class ListConversationPaymentResponse : BaseResponse
    {
        public ListConversationPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListConversationPaymentResponse()
        {
        }

        public List<ConversationPaymentDto> ConversationPayments { get; set; } = new();

        public int Count { get; set; }
    }
}