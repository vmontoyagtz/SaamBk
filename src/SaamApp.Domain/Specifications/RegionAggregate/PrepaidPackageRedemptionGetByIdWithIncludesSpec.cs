using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PrepaidPackageRedemptionByIdWithIncludesSpec : Specification<PrepaidPackageRedemption>,
        ISingleResultSpecification
    {
        public PrepaidPackageRedemptionByIdWithIncludesSpec(Guid prepaidPackageRedemptionId)
        {
            Guard.Against.NullOrEmpty(prepaidPackageRedemptionId, nameof(prepaidPackageRedemptionId));
            Query.Where(prepaidPackageRedemption =>
                    prepaidPackageRedemption.PrepaidPackageRedemptionId == prepaidPackageRedemptionId)
                .Include(a => a.Customer)
                .Include(b => b.PrepaidPackage)
                .AsNoTracking();
        }
    }
}