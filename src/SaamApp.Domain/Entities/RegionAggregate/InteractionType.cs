using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class InteractionType : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Conversation> _conversations = new();

        private readonly List<Message> _messages = new();

        private readonly List<UnansweredConversation> _unansweredConversations = new();


        private InteractionType() { } // EF required

        //[SetsRequiredMembers]
        public InteractionType(Guid interactionTypeId, string interactionTypeName, string? interactionDescription,
            Guid tenantId)
        {
            InteractionTypeId = Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            InteractionTypeName = Guard.Against.NullOrWhiteSpace(interactionTypeName, nameof(interactionTypeName));
            InteractionDescription = interactionDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid InteractionTypeId { get; private set; }

        public string InteractionTypeName { get; private set; }

        public string? InteractionDescription { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Conversation> Conversations => _conversations.AsReadOnly();
        public IEnumerable<Message> Messages => _messages.AsReadOnly();
        public IEnumerable<UnansweredConversation> UnansweredConversations => _unansweredConversations.AsReadOnly();

        public void SetInteractionTypeName(string interactionTypeName)
        {
            InteractionTypeName = Guard.Against.NullOrEmpty(interactionTypeName, nameof(interactionTypeName));
        }

        public void SetInteractionDescription(string interactionDescription)
        {
            InteractionDescription = interactionDescription;
        }
    }
}