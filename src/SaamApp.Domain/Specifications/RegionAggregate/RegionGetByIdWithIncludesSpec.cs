using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class RegionByIdWithIncludesSpec : Specification<Region>, ISingleResultSpecification
    {
        public RegionByIdWithIncludesSpec(Guid regionId)
        {
            Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            Query.Where(region => region.RegionId == regionId)
                .Include(a => a.Addresses)
                .Include(b => b.Countries)
                .ThenInclude(b => b.States)
                .ThenInclude(b => b.Addresses)
                .Include(c => c.DiscountCodes)
                .Include(c => c.GiftCodes)
                .Include(c => c.PrepaidPackages)
                .Include(c => c.RegionAreaAdvisorCategories)
                .ThenInclude(c => c.Messages)
                .AsNoTracking();
        }
    }
}