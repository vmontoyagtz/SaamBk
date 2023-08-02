using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetTemplateCategoryWithTemplateKeySpec : Specification<TemplateCategory>
    {
        public GetTemplateCategoryWithTemplateKeySpec(Guid templateId)
        {
            Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            Query.Where(tc => tc.TemplateId == templateId).AsNoTracking();
        }
    }

    public class GetTemplateDocumentWithTemplateKeySpec : Specification<TemplateDocument>
    {
        public GetTemplateDocumentWithTemplateKeySpec(Guid templateId)
        {
            Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            Query.Where(td => td.TemplateId == templateId).AsNoTracking();
        }
    }
}