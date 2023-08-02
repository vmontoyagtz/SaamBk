using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerFeedbackGuardExtensions
    {
        public static void DuplicateCustomerFeedback(this IGuardClause guardClause,
            IEnumerable<CustomerFeedback> existingCustomerFeedbacks, CustomerFeedback newCustomerFeedback,
            string parameterName)
        {
            if (existingCustomerFeedbacks.Any(a => a.FeedbackId == newCustomerFeedback.FeedbackId))
            {
                throw new DuplicateCustomerFeedbackException("Cannot add duplicate customerFeedback.", parameterName);
            }
        }
    }
}