using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AccountAdjustmentByIdWithIncludesSpec : Specification<AccountAdjustment>, ISingleResultSpecification
    {
        public AccountAdjustmentByIdWithIncludesSpec(Guid accountAdjustmentId)
        {
            Guard.Against.NullOrEmpty(accountAdjustmentId, nameof(accountAdjustmentId));
            Query.Where(accountAdjustment => accountAdjustment.AccountAdjustmentId == accountAdjustmentId)
                .Include(a => a.Account)
                .Include(b => b.AccountAdjustmentRef)
                .AsNoTracking();
        }
    }
}