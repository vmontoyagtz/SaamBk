using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerAccountGetListSpec : Specification<CustomerAccount>
    {
        public CustomerAccountGetListSpec()
        {
            Query.OrderBy(customerAccount => customerAccount.RowId)
                .AsNoTracking();
        }
    }
}