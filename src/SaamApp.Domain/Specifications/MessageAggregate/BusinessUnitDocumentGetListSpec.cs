using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitDocumentGetListSpec : Specification<BusinessUnitDocument>
    {
        public BusinessUnitDocumentGetListSpec()
        {
            Query.OrderBy(businessUnitDocument => businessUnitDocument.RowId)
                .AsNoTracking();
        }
    }
}