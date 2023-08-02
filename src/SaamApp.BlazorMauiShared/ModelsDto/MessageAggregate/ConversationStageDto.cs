using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class ConversationStageDto
    {
        public ConversationStageDto() { } // AutoMapper required

        public ConversationStageDto(Guid conversationStageId, string? conversationStageName,
            string conversationDescription, Guid tenantId)
        {
            ConversationStageId = Guard.Against.NullOrEmpty(conversationStageId, nameof(conversationStageId));
            ConversationStageName = conversationStageName;
            ConversationDescription =
                Guard.Against.NullOrWhiteSpace(conversationDescription, nameof(conversationDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid ConversationStageId { get; set; }

        [MaxLength(100)] public string? ConversationStageName { get; set; }

        [Required(ErrorMessage = "Conversation Description is required")]
        [MaxLength(100)]
        public string ConversationDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }
    }
}