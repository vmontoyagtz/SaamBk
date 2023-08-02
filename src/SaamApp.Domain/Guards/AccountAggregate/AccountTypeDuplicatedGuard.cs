using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AccountTypeGuardExtensions
    {
        public static void DuplicateAccountType(this IGuardClause guardClause,
            IEnumerable<AccountType> existingAccountTypes, AccountType newAccountType, string parameterName)
        {
            if (existingAccountTypes.Any(a => a.AccountTypeId == newAccountType.AccountTypeId))
            {
                throw new DuplicateAccountTypeException("Cannot add duplicate accountType.", parameterName);
            }
        }
    }
}