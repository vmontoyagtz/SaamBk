using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class InteractionTypeDto
    {
        public InteractionTypeDto() { } // AutoMapper required

        public InteractionTypeDto(Guid interactionTypeId, string interactionTypeName, string? interactionDescription,
            Guid tenantId)
        {
            InteractionTypeId = Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            InteractionTypeName = Guard.Against.NullOrWhiteSpace(interactionTypeName, nameof(interactionTypeName));
            InteractionDescription = interactionDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid InteractionTypeId { get; set; }

        [Required(ErrorMessage = "Interaction Type Name is required")]
        [MaxLength(100)]
        public string InteractionTypeName { get; set; }

        [MaxLength(100)] public string? InteractionDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<ConversationDto> Conversations { get; set; } = new();
        public List<MessageDto> Messages { get; set; } = new();
        public List<UnansweredConversationDto> UnansweredConversations { get; set; } = new();
    }
}