using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorRatingWithConversationKeySpec : Specification<AdvisorRating>
    {
        public GetAdvisorRatingWithConversationKeySpec(Guid conversationId)
        {
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Query.Where(ar => ar.ConversationId == conversationId).AsNoTracking();
        }
    }

    public class GetConversationPaymentWithConversationKeySpec : Specification<ConversationPayment>
    {
        public GetConversationPaymentWithConversationKeySpec(Guid conversationId)
        {
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Query.Where(cp => cp.ConversationId == conversationId).AsNoTracking();
        }
    }

    public class GetMessageWithConversationKeySpec : Specification<Message>
    {
        public GetMessageWithConversationKeySpec(Guid conversationId)
        {
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Query.Where(m => m.ConversationId == conversationId).AsNoTracking();
        }
    }
}