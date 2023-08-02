using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAccountAdjustmentWithAccountAdjustmentRefKeySpec : Specification<AccountAdjustment>
    {
        public GetAccountAdjustmentWithAccountAdjustmentRefKeySpec(Guid accountAdjustmentRefId)
        {
            Guard.Against.NullOrEmpty(accountAdjustmentRefId, nameof(accountAdjustmentRefId));
            Query.Where(aa => aa.AccountAdjustmentRefId == accountAdjustmentRefId).AsNoTracking();
        }
    }
}