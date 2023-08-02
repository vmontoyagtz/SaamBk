using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerPurchaseGetListSpec : Specification<CustomerPurchase>
    {
        public CustomerPurchaseGetListSpec()
        {
            Query.Where(customerPurchase => customerPurchase.IsPositive == true)
                .AsNoTracking();
        }
    }
}