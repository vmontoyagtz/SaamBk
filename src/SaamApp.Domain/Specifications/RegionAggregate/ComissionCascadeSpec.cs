using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAiRobotCategoryWithComissionKeySpec : Specification<AiRobotCategory>
    {
        public GetAiRobotCategoryWithComissionKeySpec(Guid comissionId)
        {
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Query.Where(arc => arc.ComissionId == comissionId).AsNoTracking();
        }
    }

    public class GetProductCategoryWithComissionKeySpec : Specification<ProductCategory>
    {
        public GetProductCategoryWithComissionKeySpec(Guid comissionId)
        {
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Query.Where(pc => pc.ComissionId == comissionId).AsNoTracking();
        }
    }

    public class GetTemplateCategoryWithComissionKeySpec : Specification<TemplateCategory>
    {
        public GetTemplateCategoryWithComissionKeySpec(Guid comissionId)
        {
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Query.Where(tc => tc.ComissionId == comissionId).AsNoTracking();
        }
    }
}