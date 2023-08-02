using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ConversationPaymentByRelIdsSpec : Specification<ConversationPayment>
    {
        public ConversationPaymentByRelIdsSpec(Guid advisorPaymentId, Guid conversationId)
        {
            Guard.Against.NullOrEmpty(advisorPaymentId, nameof(advisorPaymentId));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Query.Where(conversationPayment => conversationPayment.AdvisorPaymentId == advisorPaymentId &&
                                               conversationPayment.ConversationId == conversationId).AsNoTracking();
        }
    }
}