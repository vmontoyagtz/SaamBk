using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAccountAdjustmentWithAccountKeySpec : Specification<AccountAdjustment>
    {
        public GetAccountAdjustmentWithAccountKeySpec(Guid accountId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Query.Where(aa => aa.AccountId == accountId).AsNoTracking();
        }
    }

    public class GetCustomerAccountWithAccountKeySpec : Specification<CustomerAccount>
    {
        public GetCustomerAccountWithAccountKeySpec(Guid accountId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Query.Where(ca => ca.AccountId == accountId).AsNoTracking();
        }
    }

    public class GetInvoiceWithAccountKeySpec : Specification<Invoice>
    {
        public GetInvoiceWithAccountKeySpec(Guid accountId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Query.Where(i => i.AccountId == accountId).AsNoTracking();
        }
    }

    public class GetJournalEntryLineWithAccountKeySpec : Specification<JournalEntryLine>
    {
        public GetJournalEntryLineWithAccountKeySpec(Guid accountId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Query.Where(jel => jel.AccountId == accountId).AsNoTracking();
        }
    }
}