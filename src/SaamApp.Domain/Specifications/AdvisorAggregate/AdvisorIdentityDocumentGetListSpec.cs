using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorIdentityDocumentGetListSpec : Specification<AdvisorIdentityDocument>
    {
        public AdvisorIdentityDocumentGetListSpec()
        {
            Query.OrderBy(advisorIdentityDocument => advisorIdentityDocument.RowId)
                .AsNoTracking();
        }
    }
}