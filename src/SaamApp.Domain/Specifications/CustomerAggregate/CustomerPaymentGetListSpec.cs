using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerPaymentGetListSpec : Specification<CustomerPayment>
    {
        public CustomerPaymentGetListSpec()
        {
            Query.OrderBy(customerPayment => customerPayment.RowId)
                .AsNoTracking();
        }
    }
}