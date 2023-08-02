using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerEmailAddressGetListSpec : Specification<CustomerEmailAddress>
    {
        public CustomerEmailAddressGetListSpec()
        {
            Query.OrderBy(customerEmailAddress => customerEmailAddress.RowId)
                .AsNoTracking();
        }
    }
}