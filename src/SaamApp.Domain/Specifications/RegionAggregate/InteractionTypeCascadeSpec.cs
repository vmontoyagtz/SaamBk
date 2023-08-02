using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetConversationWithInteractionTypeKeySpec : Specification<Conversation>
    {
        public GetConversationWithInteractionTypeKeySpec(Guid interactionTypeId)
        {
            Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            Query.Where(c => c.InteractionTypeId == interactionTypeId).AsNoTracking();
        }
    }

    public class GetMessageWithInteractionTypeKeySpec : Specification<Message>
    {
        public GetMessageWithInteractionTypeKeySpec(Guid interactionTypeId)
        {
            Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            Query.Where(m => m.InteractionTypeId == interactionTypeId).AsNoTracking();
        }
    }

    public class GetUnansweredConversationWithInteractionTypeKeySpec : Specification<UnansweredConversation>
    {
        public GetUnansweredConversationWithInteractionTypeKeySpec(Guid interactionTypeId)
        {
            Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            Query.Where(uc => uc.InteractionTypeId == interactionTypeId).AsNoTracking();
        }
    }
}