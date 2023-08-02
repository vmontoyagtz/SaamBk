using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorRatingWithRatingReasonKeySpec : Specification<AdvisorRating>
    {
        public GetAdvisorRatingWithRatingReasonKeySpec(Guid ratingReasonId)
        {
            Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));
            Query.Where(ar => ar.RatingReasonId == ratingReasonId).AsNoTracking();
        }
    }
}