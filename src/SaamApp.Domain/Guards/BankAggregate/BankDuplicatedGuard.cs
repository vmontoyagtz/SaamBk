using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BankGuardExtensions
    {
        public static void DuplicateBank(this IGuardClause guardClause, IEnumerable<Bank> existingBanks, Bank newBank,
            string parameterName)
        {
            if (existingBanks.Any(a => a.BankId == newBank.BankId))
            {
                throw new DuplicateBankException("Cannot add duplicate bank.", parameterName);
            }
        }
    }
}