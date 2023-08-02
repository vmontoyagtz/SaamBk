using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AreaByIdWithIncludesSpec : Specification<Area>, ISingleResultSpecification
    {
        public AreaByIdWithIncludesSpec(Guid areaId)
        {
            Guard.Against.NullOrEmpty(areaId, nameof(areaId));
            Query.Where(area => area.AreaId == areaId)
                .Include(a => a.RegionAreaAdvisorCategories)
                .ThenInclude(a => a.Messages)
                .AsNoTracking();
        }
    }
}