using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class GetByIdConversationPaymentResponse : BaseResponse
    {
        public GetByIdConversationPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdConversationPaymentResponse()
        {
        }

        public ConversationPaymentDto ConversationPayment { get; set; } = new();
    }
}