using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerReviewGetListSpec : Specification<CustomerReview>
    {
        public CustomerReviewGetListSpec()
        {
            Query.Where(customerReview => customerReview.IsDeleted == false)
                .AsNoTracking();
        }
    }
}