using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiAreaExpertiseByRelIdsSpec : Specification<AiAreaExpertise>
    {
        public AiAreaExpertiseByRelIdsSpec(Guid modelId, Guid regionAreaAdvisorCategoryId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            Query.Where(aiAreaExpertise => aiAreaExpertise.ModelId == modelId &&
                                           aiAreaExpertise.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId &&
                                           aiAreaExpertise.TenantId == tenantId).AsNoTracking();
        }
    }
}