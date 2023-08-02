using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetPrepaidPackageRedemptionWithPrepaidPackageKeySpec : Specification<PrepaidPackageRedemption>
    {
        public GetPrepaidPackageRedemptionWithPrepaidPackageKeySpec(Guid prepaidPackageId)
        {
            Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            Query.Where(ppr => ppr.PrepaidPackageId == prepaidPackageId).AsNoTracking();
        }
    }

    public class GetSerfinsaPaymentWithPrepaidPackageKeySpec : Specification<SerfinsaPayment>
    {
        public GetSerfinsaPaymentWithPrepaidPackageKeySpec(Guid prepaidPackageId)
        {
            Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            Query.Where(sp => sp.PrepaidPackageId == prepaidPackageId).AsNoTracking();
        }
    }
}