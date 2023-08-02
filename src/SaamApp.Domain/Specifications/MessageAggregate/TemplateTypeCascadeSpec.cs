using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetTemplateWithTemplateTypeKeySpec : Specification<Template>
    {
        public GetTemplateWithTemplateTypeKeySpec(Guid templateTypeId)
        {
            Guard.Against.NullOrEmpty(templateTypeId, nameof(templateTypeId));
            Query.Where(t => t.TemplateTypeId == templateTypeId).AsNoTracking();
        }
    }
}