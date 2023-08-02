using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerReviewByIdWithIncludesSpec : Specification<CustomerReview>, ISingleResultSpecification
    {
        public CustomerReviewByIdWithIncludesSpec(Guid customerReviewId)
        {
            Guard.Against.NullOrEmpty(customerReviewId, nameof(customerReviewId));
            Query.Where(customerReview => customerReview.CustomerReviewId == customerReviewId)
                .Include(a => a.Advisor)
                .Include(b => b.Customer)
                .AsNoTracking();
        }
    }
}