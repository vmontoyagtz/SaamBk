using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorBankTransferInfoByIdWithIncludesSpec : Specification<AdvisorBankTransferInfo>,
        ISingleResultSpecification
    {
        public AdvisorBankTransferInfoByIdWithIncludesSpec(Guid advisorBankTransferInfoId)
        {
            Guard.Against.NullOrEmpty(advisorBankTransferInfoId, nameof(advisorBankTransferInfoId));
            Query.Where(advisorBankTransferInfo =>
                    advisorBankTransferInfo.AdvisorBankTransferInfoId == advisorBankTransferInfoId)
                .Include(a => a.Advisor)
                .Include(b => b.BankAccount)
                .AsNoTracking();
        }
    }
}