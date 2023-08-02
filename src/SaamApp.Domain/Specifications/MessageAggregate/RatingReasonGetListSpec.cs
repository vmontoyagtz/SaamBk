using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class RatingReasonGetListSpec : Specification<RatingReason>
    {
        public RatingReasonGetListSpec()
        {
            Query.OrderBy(ratingReason => ratingReason.RatingReasonId)
                .AsNoTracking();
        }
    }
}