using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerFeedbackByIdWithIncludesSpec : Specification<CustomerFeedback>, ISingleResultSpecification
    {
        public CustomerFeedbackByIdWithIncludesSpec(Guid feedbackId)
        {
            Guard.Against.NullOrEmpty(feedbackId, nameof(feedbackId));
            Query.Where(customerFeedback => customerFeedback.FeedbackId == feedbackId)
                .Include(a => a.Customer)
                .AsNoTracking();
        }
    }
}