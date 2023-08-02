using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerAddressGetListSpec : Specification<CustomerAddress>
    {
        public CustomerAddressGetListSpec()
        {
            Query.OrderBy(customerAddress => customerAddress.RowId)
                .AsNoTracking();
        }
    }
}