using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetConversationWithUnansweredConversationKeySpec : Specification<Conversation>
    {
        public GetConversationWithUnansweredConversationKeySpec(Guid unansweredConversationId)
        {
            Guard.Against.NullOrEmpty(unansweredConversationId, nameof(unansweredConversationId));
            Query.Where(c => c.UnansweredConversationId == unansweredConversationId).AsNoTracking();
        }
    }
}