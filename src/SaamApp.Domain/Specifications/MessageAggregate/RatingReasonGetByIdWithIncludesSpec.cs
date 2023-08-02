using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class RatingReasonByIdWithIncludesSpec : Specification<RatingReason>, ISingleResultSpecification
    {
        public RatingReasonByIdWithIncludesSpec(Guid ratingReasonId)
        {
            Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));
            Query.Where(ratingReason => ratingReason.RatingReasonId == ratingReasonId)
                .Include(a => a.AdvisorRatings)
                .ThenInclude(b => b.Advisor).Include(b => b.AdvisorRatings).ThenInclude(b => b.Conversation)
                .Include(b => b.AdvisorRatings).ThenInclude(b => b.Customer)
                .AsNoTracking();
        }
    }
}