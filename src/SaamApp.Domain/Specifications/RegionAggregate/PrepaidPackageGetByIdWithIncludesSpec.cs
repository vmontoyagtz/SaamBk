using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PrepaidPackageByIdWithIncludesSpec : Specification<PrepaidPackage>, ISingleResultSpecification
    {
        public PrepaidPackageByIdWithIncludesSpec(Guid prepaidPackageId)
        {
            Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            Query.Where(prepaidPackage => prepaidPackage.PrepaidPackageId == prepaidPackageId)
                .Include(a => a.Region)
                .Include(b => b.PrepaidPackageRedemptions)
                .ThenInclude(c => c.Customer)
                .Include(c => c.SerfinsaPayments)
                .AsNoTracking();
        }
    }
}