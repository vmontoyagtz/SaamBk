using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class ConversationStage : BaseEntityEv<Guid>, IAggregateRoot
    {
        private ConversationStage() { } // EF required

        //[SetsRequiredMembers]
        public ConversationStage(Guid conversationStageId, string? conversationStageName,
            string conversationDescription, Guid tenantId)
        {
            ConversationStageId = Guard.Against.NullOrEmpty(conversationStageId, nameof(conversationStageId));
            ConversationStageName = conversationStageName;
            ConversationDescription =
                Guard.Against.NullOrWhiteSpace(conversationDescription, nameof(conversationDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid ConversationStageId { get; private set; }

        public string? ConversationStageName { get; private set; }

        public string ConversationDescription { get; private set; }

        public Guid TenantId { get; private set; }

        public void SetConversationStageName(string conversationStageName)
        {
            ConversationStageName = conversationStageName;
        }

        public void SetConversationDescription(string conversationDescription)
        {
            ConversationDescription =
                Guard.Against.NullOrEmpty(conversationDescription, nameof(conversationDescription));
        }
    }
}