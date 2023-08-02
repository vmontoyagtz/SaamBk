using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorDocumentGetListSpec : Specification<AdvisorDocument>
    {
        public AdvisorDocumentGetListSpec()
        {
            Query.OrderBy(advisorDocument => advisorDocument.RowId)
                .AsNoTracking();
        }
    }
}