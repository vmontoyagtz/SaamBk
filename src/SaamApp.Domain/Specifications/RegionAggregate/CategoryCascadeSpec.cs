using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetRegionAreaAdvisorCategoryWithCategoryKeySpec : Specification<RegionAreaAdvisorCategory>
    {
        public GetRegionAreaAdvisorCategoryWithCategoryKeySpec(Guid categoryId)
        {
            Guard.Against.NullOrEmpty(categoryId, nameof(categoryId));
            Query.Where(raac => raac.CategoryId == categoryId).AsNoTracking();
        }
    }
}