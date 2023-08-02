using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAddressWithRegionKeySpec : Specification<Address>
    {
        public GetAddressWithRegionKeySpec(Guid regionId)
        {
            Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            Query.Where(a => a.RegionId == regionId).AsNoTracking();
        }
    }

    public class GetCountryWithRegionKeySpec : Specification<Country>
    {
        public GetCountryWithRegionKeySpec(Guid regionId)
        {
            Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            Query.Where(c => c.RegionId == regionId).AsNoTracking();
        }
    }

    public class GetDiscountCodeWithRegionKeySpec : Specification<DiscountCode>
    {
        public GetDiscountCodeWithRegionKeySpec(Guid regionId)
        {
            Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            Query.Where(dc => dc.RegionId == regionId).AsNoTracking();
        }
    }

    public class GetGiftCodeWithRegionKeySpec : Specification<GiftCode>
    {
        public GetGiftCodeWithRegionKeySpec(Guid regionId)
        {
            Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            Query.Where(gc => gc.RegionId == regionId).AsNoTracking();
        }
    }

    public class GetPrepaidPackageWithRegionKeySpec : Specification<PrepaidPackage>
    {
        public GetPrepaidPackageWithRegionKeySpec(Guid regionId)
        {
            Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            Query.Where(pp => pp.RegionId == regionId).AsNoTracking();
        }
    }

    public class GetRegionAreaAdvisorCategoryWithRegionKeySpec : Specification<RegionAreaAdvisorCategory>
    {
        public GetRegionAreaAdvisorCategoryWithRegionKeySpec(Guid regionId)
        {
            Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            Query.Where(raac => raac.RegionId == regionId).AsNoTracking();
        }
    }
}