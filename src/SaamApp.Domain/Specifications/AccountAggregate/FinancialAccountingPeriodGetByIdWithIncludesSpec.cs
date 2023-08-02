using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class FinancialAccountingPeriodByIdWithIncludesSpec : Specification<FinancialAccountingPeriod>,
        ISingleResultSpecification
    {
        public FinancialAccountingPeriodByIdWithIncludesSpec(Guid financialAccountingPeriodId)
        {
            Guard.Against.NullOrEmpty(financialAccountingPeriodId, nameof(financialAccountingPeriodId));
            Query.Where(financialAccountingPeriod =>
                    financialAccountingPeriod.FinancialAccountingPeriodId == financialAccountingPeriodId)
                .Include(a => a.Invoices)
                .ThenInclude(b => b.Account)
                .Include(b => b.JournalEntryLines)
                .ThenInclude(c => c.Account)
                .AsNoTracking();
        }
    }
}