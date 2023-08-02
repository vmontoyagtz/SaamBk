using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerAiHistoryGuardExtensions
    {
        public static void DuplicateCustomerAiHistory(this IGuardClause guardClause,
            IEnumerable<CustomerAiHistory> existingCustomerAiHistories, CustomerAiHistory newCustomerAiHistory,
            string parameterName)
        {
            if (existingCustomerAiHistories.Any(a => a.CustomerAiHistoryId == newCustomerAiHistory.CustomerAiHistoryId))
            {
                throw new DuplicateCustomerAiHistoryException("Cannot add duplicate customerAiHistory.", parameterName);
            }
        }
    }
}