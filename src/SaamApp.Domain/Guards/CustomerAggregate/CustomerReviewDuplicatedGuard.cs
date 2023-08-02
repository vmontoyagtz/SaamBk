using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerReviewGuardExtensions
    {
        public static void DuplicateCustomerReview(this IGuardClause guardClause,
            IEnumerable<CustomerReview> existingCustomerReviews, CustomerReview newCustomerReview, string parameterName)
        {
            if (existingCustomerReviews.Any(a => a.CustomerReviewId == newCustomerReview.CustomerReviewId))
            {
                throw new DuplicateCustomerReviewException("Cannot add duplicate customerReview.", parameterName);
            }
        }
    }
}