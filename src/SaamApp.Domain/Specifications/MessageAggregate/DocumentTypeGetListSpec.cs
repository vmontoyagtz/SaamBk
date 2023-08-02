using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class DocumentTypeGetListSpec : Specification<DocumentType>
    {
        public DocumentTypeGetListSpec()
        {
            Query.OrderBy(documentType => documentType.DocumentTypeId)
                .AsNoTracking();
        }
    }
}