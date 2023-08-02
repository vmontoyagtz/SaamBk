using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CustomerAccountGuardExtensions
    {
        public static void DuplicateCustomerAccount(this IGuardClause guardClause,
            IEnumerable<CustomerAccount> existingCustomerAccounts, CustomerAccount newCustomerAccount,
            string parameterName)
        {
            if (existingCustomerAccounts.Any(a => a.RowId == newCustomerAccount.RowId))
            {
                throw new DuplicateCustomerAccountException("Cannot add duplicate customerAccount.", parameterName);
            }
        }
    }
}