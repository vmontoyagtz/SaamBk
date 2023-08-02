using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorPaymentGuardExtensions
    {
        public static void DuplicateAdvisorPayment(this IGuardClause guardClause,
            IEnumerable<AdvisorPayment> existingAdvisorPayments, AdvisorPayment newAdvisorPayment, string parameterName)
        {
            if (existingAdvisorPayments.Any(a => a.RowId == newAdvisorPayment.RowId))
            {
                throw new DuplicateAdvisorPaymentException("Cannot add duplicate advisorPayment.", parameterName);
            }
        }
    }
}