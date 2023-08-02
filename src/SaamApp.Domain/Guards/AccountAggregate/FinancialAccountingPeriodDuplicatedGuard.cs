using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class FinancialAccountingPeriodGuardExtensions
    {
        public static void DuplicateFinancialAccountingPeriod(this IGuardClause guardClause,
            IEnumerable<FinancialAccountingPeriod> existingFinancialAccountingPeriods,
            FinancialAccountingPeriod newFinancialAccountingPeriod, string parameterName)
        {
            if (existingFinancialAccountingPeriods.Any(a =>
                    a.FinancialAccountingPeriodId == newFinancialAccountingPeriod.FinancialAccountingPeriodId))
            {
                throw new DuplicateFinancialAccountingPeriodException("Cannot add duplicate financialAccountingPeriod.",
                    parameterName);
            }
        }
    }
}