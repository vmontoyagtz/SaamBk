using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ConversationPayment
{
    public class UpdateConversationPaymentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid AdvisorPaymentId { get; set; }
        public bool? ConversationPaymentStage { get; set; }

        public static UpdateConversationPaymentRequest FromDto(ConversationPaymentDto conversationPaymentDto)
        {
            return new UpdateConversationPaymentRequest
            {
                RowId = conversationPaymentDto.RowId,
                ConversationId = conversationPaymentDto.ConversationId,
                AdvisorPaymentId = conversationPaymentDto.AdvisorPaymentId,
                ConversationPaymentStage = conversationPaymentDto.ConversationPaymentStage
            };
        }
    }
}