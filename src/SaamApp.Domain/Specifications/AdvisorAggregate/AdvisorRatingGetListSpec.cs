using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorRatingGetListSpec : Specification<AdvisorRating>
    {
        public AdvisorRatingGetListSpec()
        {
            Query.OrderBy(advisorRating => advisorRating.RowId)
                .AsNoTracking();
        }
    }
}