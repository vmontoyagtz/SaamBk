using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorBankByRelIdsSpec : Specification<AdvisorBank>
    {
        public AdvisorBankByRelIdsSpec(bool isDefault, Guid advisorId, Guid bankAccountId)
        {
            Guard.Against.Null(isDefault, nameof(isDefault));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Query.Where(advisorBank => advisorBank.IsDefault == isDefault && advisorBank.AdvisorId == advisorId &&
                                       advisorBank.BankAccountId == bankAccountId).AsNoTracking();
        }
    }
}