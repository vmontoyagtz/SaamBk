using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorBankWithBankAccountKeySpec : Specification<AdvisorBank>
    {
        public GetAdvisorBankWithBankAccountKeySpec(Guid bankAccountId)
        {
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Query.Where(ab => ab.BankAccountId == bankAccountId).AsNoTracking();
        }
    }

    public class GetAdvisorBankTransferInfoWithBankAccountKeySpec : Specification<AdvisorBankTransferInfo>
    {
        public GetAdvisorBankTransferInfoWithBankAccountKeySpec(Guid bankAccountId)
        {
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Query.Where(abti => abti.BankAccountId == bankAccountId).AsNoTracking();
        }
    }

    public class GetAdvisorPaymentWithBankAccountKeySpec : Specification<AdvisorPayment>
    {
        public GetAdvisorPaymentWithBankAccountKeySpec(Guid bankAccountId)
        {
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Query.Where(ap => ap.BankAccountId == bankAccountId).AsNoTracking();
        }
    }
}