using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TemplateCategoryGetListSpec : Specification<TemplateCategory>
    {
        public TemplateCategoryGetListSpec()
        {
            Query.OrderBy(templateCategory => templateCategory.RowId)
                .AsNoTracking();
        }
    }
}