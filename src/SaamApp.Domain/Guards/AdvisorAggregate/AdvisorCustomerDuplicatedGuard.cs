using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorCustomerGuardExtensions
    {
        public static void DuplicateAdvisorCustomer(this IGuardClause guardClause,
            IEnumerable<AdvisorCustomer> existingAdvisorCustomers, AdvisorCustomer newAdvisorCustomer,
            string parameterName)
        {
            if (existingAdvisorCustomers.Any(a => a.RowId == newAdvisorCustomer.RowId))
            {
                throw new DuplicateAdvisorCustomerException("Cannot add duplicate advisorCustomer.", parameterName);
            }
        }
    }
}