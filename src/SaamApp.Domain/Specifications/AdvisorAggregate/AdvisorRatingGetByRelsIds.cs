using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorRatingByRelIdsSpec : Specification<AdvisorRating>
    {
        public AdvisorRatingByRelIdsSpec(int advisorRatingRate, DateTime advisorRatingDate, Guid advisorId,
            Guid conversationId, Guid customerId, Guid ratingReasonId)
        {
            Guard.Against.NegativeOrZero(advisorRatingRate, nameof(advisorRatingRate));
            Guard.Against.OutOfSQLDateRange(advisorRatingDate, nameof(advisorRatingDate));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));
            Query.Where(advisorRating => advisorRating.AdvisorRatingRate == advisorRatingRate &&
                                         advisorRating.AdvisorRatingDate == advisorRatingDate &&
                                         advisorRating.AdvisorId == advisorId &&
                                         advisorRating.ConversationId == conversationId &&
                                         advisorRating.CustomerId == customerId &&
                                         advisorRating.RatingReasonId == ratingReasonId).AsNoTracking();
        }
    }
}