using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorBankGuardExtensions
    {
        public static void DuplicateAdvisorBank(this IGuardClause guardClause,
            IEnumerable<AdvisorBank> existingAdvisorBanks, AdvisorBank newAdvisorBank, string parameterName)
        {
            if (existingAdvisorBanks.Any(a => a.RowId == newAdvisorBank.RowId))
            {
                throw new DuplicateAdvisorBankException("Cannot add duplicate advisorBank.", parameterName);
            }
        }
    }
}