using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ConversationByIdWithIncludesSpec : Specification<Conversation>, ISingleResultSpecification
    {
        public ConversationByIdWithIncludesSpec(Guid conversationId)
        {
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Query.Where(conversation => conversation.ConversationId == conversationId)
                .Include(a => a.InteractionType)
                .Include(b => b.RegionAreaAdvisorCategory)
                .Include(c => c.UnansweredConversation)
                .Include(d => d.AdvisorRatings)
                .ThenInclude(e => e.Advisor).Include(e => e.AdvisorRatings).ThenInclude(e => e.Customer)
                .Include(e => e.AdvisorRatings).ThenInclude(e => e.RatingReason)
                .Include(e => e.ConversationPayments)
                .Include(e => e.Messages)
                .AsNoTracking();
        }
    }
}