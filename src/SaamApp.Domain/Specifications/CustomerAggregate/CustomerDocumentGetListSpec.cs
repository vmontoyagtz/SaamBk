using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerDocumentGetListSpec : Specification<CustomerDocument>
    {
        public CustomerDocumentGetListSpec()
        {
            Query.OrderBy(customerDocument => customerDocument.RowId)
                .AsNoTracking();
        }
    }
}