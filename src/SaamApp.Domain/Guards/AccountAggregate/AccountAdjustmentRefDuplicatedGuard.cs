using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AccountAdjustmentRefGuardExtensions
    {
        public static void DuplicateAccountAdjustmentRef(this IGuardClause guardClause,
            IEnumerable<AccountAdjustmentRef> existingAccountAdjustmentRefs,
            AccountAdjustmentRef newAccountAdjustmentRef, string parameterName)
        {
            if (existingAccountAdjustmentRefs.Any(a =>
                    a.AccountAdjustmentRefId == newAccountAdjustmentRef.AccountAdjustmentRefId))
            {
                throw new DuplicateAccountAdjustmentRefException("Cannot add duplicate accountAdjustmentRef.",
                    parameterName);
            }
        }
    }
}