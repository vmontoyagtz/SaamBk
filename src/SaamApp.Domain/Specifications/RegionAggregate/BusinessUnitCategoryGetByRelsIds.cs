using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitCategoryByRelIdsSpec : Specification<BusinessUnitCategory>
    {
        public BusinessUnitCategoryByRelIdsSpec(Guid regionAreaAdvisorCategoryId, Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(businessUnitCategory =>
                businessUnitCategory.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId &&
                businessUnitCategory.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }
}