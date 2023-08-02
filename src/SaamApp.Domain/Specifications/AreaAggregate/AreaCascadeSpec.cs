using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetRegionAreaAdvisorCategoryWithAreaKeySpec : Specification<RegionAreaAdvisorCategory>
    {
        public GetRegionAreaAdvisorCategoryWithAreaKeySpec(Guid areaId)
        {
            Guard.Against.NullOrEmpty(areaId, nameof(areaId));
            Query.Where(raac => raac.AreaId == areaId).AsNoTracking();
        }
    }
}