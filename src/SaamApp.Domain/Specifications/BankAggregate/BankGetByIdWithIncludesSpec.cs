using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BankByIdWithIncludesSpec : Specification<Bank>, ISingleResultSpecification
    {
        public BankByIdWithIncludesSpec(Guid bankId)
        {
            Guard.Against.NullOrEmpty(bankId, nameof(bankId));
            Query.Where(bank => bank.BankId == bankId)
                .Include(a => a.BankAccounts)
                .AsNoTracking();
        }
    }
}