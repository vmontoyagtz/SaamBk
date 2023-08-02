using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class DocumentGetListSpec : Specification<Document>
    {
        public DocumentGetListSpec()
        {
            Query.OrderBy(document => document.DocumentId)
                .AsNoTracking();
        }
    }
}