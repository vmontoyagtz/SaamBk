using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetBankAccountWithBankKeySpec : Specification<BankAccount>
    {
        public GetBankAccountWithBankKeySpec(Guid bankId)
        {
            Guard.Against.NullOrEmpty(bankId, nameof(bankId));
            Query.Where(ba => ba.BankId == bankId).AsNoTracking();
        }
    }
}