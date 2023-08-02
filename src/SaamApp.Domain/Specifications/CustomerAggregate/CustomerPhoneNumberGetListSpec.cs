using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerPhoneNumberGetListSpec : Specification<CustomerPhoneNumber>
    {
        public CustomerPhoneNumberGetListSpec()
        {
            Query.OrderBy(customerPhoneNumber => customerPhoneNumber.RowId)
                .AsNoTracking();
        }
    }
}