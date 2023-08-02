using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BankAccountByIdWithIncludesSpec : Specification<BankAccount>, ISingleResultSpecification
    {
        public BankAccountByIdWithIncludesSpec(Guid bankAccountId)
        {
            Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            Query.Where(bankAccount => bankAccount.BankAccountId == bankAccountId)
                .Include(a => a.Bank)
                .Include(b => b.AdvisorBanks)
                .ThenInclude(c => c.Advisor)
                .Include(c => c.AdvisorBankTransferInfoes)
                .ThenInclude(d => d.Advisor)
                .Include(d => d.AdvisorPayments)
                .ThenInclude(e => e.Advisor).Include(e => e.AdvisorPayments).ThenInclude(e => e.PaymentMethod)
                .AsNoTracking();
        }
    }
}