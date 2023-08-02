using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TemplateGetListSpec : Specification<Template>
    {
        public TemplateGetListSpec()
        {
            Query.Where(template => template.TemplateIsActive == true)
                .AsNoTracking();
        }
    }
}