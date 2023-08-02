using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class IdentityDocumentGetListSpec : Specification<IdentityDocument>
    {
        public IdentityDocumentGetListSpec()
        {
            Query.OrderBy(identityDocument => identityDocument.IdentityDocumentId)
                .AsNoTracking();
        }
    }
}