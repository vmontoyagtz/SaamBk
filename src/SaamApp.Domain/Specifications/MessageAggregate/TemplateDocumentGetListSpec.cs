using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TemplateDocumentGetListSpec : Specification<TemplateDocument>
    {
        public TemplateDocumentGetListSpec()
        {
            Query.OrderBy(templateDocument => templateDocument.RowId)
                .AsNoTracking();
        }
    }
}