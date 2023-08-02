using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AccountStateTypeGuardExtensions
    {
        public static void DuplicateAccountStateType(this IGuardClause guardClause,
            IEnumerable<AccountStateType> existingAccountStateTypes, AccountStateType newAccountStateType,
            string parameterName)
        {
            if (existingAccountStateTypes.Any(a => a.AccountStateTypeId == newAccountStateType.AccountStateTypeId))
            {
                throw new DuplicateAccountStateTypeException("Cannot add duplicate accountStateType.", parameterName);
            }
        }
    }
}