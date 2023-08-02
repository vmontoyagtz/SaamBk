using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class ConversationPaymentDto
    {
        public ConversationPaymentDto() { } // AutoMapper required

        public ConversationPaymentDto(Guid conversationId, Guid advisorPaymentId, bool? conversationPaymentStage)
        {
            ConversationId = Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            AdvisorPaymentId = Guard.Against.NullOrEmpty(advisorPaymentId, nameof(advisorPaymentId));
            ConversationPaymentStage = conversationPaymentStage;
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Advisor Payment Id is required")]
        public Guid AdvisorPaymentId { get; set; }

        public bool? ConversationPaymentStage { get; set; }

        public ConversationDto Conversation { get; set; }

        [Required(ErrorMessage = "Conversation is required")]
        public Guid ConversationId { get; set; }
    }
}