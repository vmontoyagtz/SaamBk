using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TemplateTypeGetListSpec : Specification<TemplateType>
    {
        public TemplateTypeGetListSpec()
        {
            Query.OrderBy(templateType => templateType.TemplateTypeId)
                .AsNoTracking();
        }
    }
}