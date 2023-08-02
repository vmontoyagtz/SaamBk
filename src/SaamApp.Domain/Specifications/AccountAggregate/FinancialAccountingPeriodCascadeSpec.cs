using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetInvoiceWithFinancialAccountingPeriodKeySpec : Specification<Invoice>
    {
        public GetInvoiceWithFinancialAccountingPeriodKeySpec(Guid financialAccountingPeriodId)
        {
            Guard.Against.NullOrEmpty(financialAccountingPeriodId, nameof(financialAccountingPeriodId));
            Query.Where(i => i.FinancialAccountingPeriodId == financialAccountingPeriodId).AsNoTracking();
        }
    }

    public class GetJournalEntryLineWithFinancialAccountingPeriodKeySpec : Specification<JournalEntryLine>
    {
        public GetJournalEntryLineWithFinancialAccountingPeriodKeySpec(Guid financialAccountingPeriodId)
        {
            Guard.Against.NullOrEmpty(financialAccountingPeriodId, nameof(financialAccountingPeriodId));
            Query.Where(jel => jel.FinancialAccountingPeriodId == financialAccountingPeriodId).AsNoTracking();
        }
    }
}