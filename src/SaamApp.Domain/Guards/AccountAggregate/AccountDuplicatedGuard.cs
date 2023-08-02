using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AccountGuardExtensions
    {
        public static void DuplicateAccount(this IGuardClause guardClause, IEnumerable<Account> existingAccounts,
            Account newAccount, string parameterName)
        {
            if (existingAccounts.Any(a => a.AccountId == newAccount.AccountId))
            {
                throw new DuplicateAccountException("Cannot add duplicate account.", parameterName);
            }
        }
    }
}