using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TemplateCategoryByRelIdsSpec : Specification<TemplateCategory>
    {
        public TemplateCategoryByRelIdsSpec(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid templateId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            Query.Where(templateCategory =>
                templateCategory.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId &&
                templateCategory.ComissionId == comissionId && templateCategory.TemplateId == templateId &&
                templateCategory.TenantId == tenantId).AsNoTracking();
        }
    }
}