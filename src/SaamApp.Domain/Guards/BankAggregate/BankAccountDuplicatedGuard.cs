using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BankAccountGuardExtensions
    {
        public static void DuplicateBankAccount(this IGuardClause guardClause,
            IEnumerable<BankAccount> existingBankAccounts, BankAccount newBankAccount, string parameterName)
        {
            if (existingBankAccounts.Any(a => a.BankAccountId == newBankAccount.BankAccountId))
            {
                throw new DuplicateBankAccountException("Cannot add duplicate bankAccount.", parameterName);
            }
        }
    }
}