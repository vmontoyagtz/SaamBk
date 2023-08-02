using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AccountByIdWithIncludesSpec : Specification<Account>, ISingleResultSpecification
    {
        public AccountByIdWithIncludesSpec(Guid accountId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Query.Where(account => account.AccountId == accountId)
                .Include(a => a.AccountStateType)
                .Include(b => b.AccountType)
                .Include(c => c.TaxInformation)
                .Include(d => d.AccountAdjustments)
                .ThenInclude(e => e.AccountAdjustmentRef)
                .Include(e => e.CustomerAccounts)
                .ThenInclude(f => f.Customer)
                .Include(f => f.Invoices)
                .ThenInclude(g => g.FinancialAccountingPeriod)
                .Include(g => g.JournalEntryLines)
                .ThenInclude(h => h.FinancialAccountingPeriod)
                .AsNoTracking();
        }
    }
}