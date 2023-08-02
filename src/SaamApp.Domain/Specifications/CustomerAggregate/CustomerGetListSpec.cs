using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerGetListSpec : Specification<Customer>
    {
        public CustomerGetListSpec()
        {
            Query.Where(customer => customer.IsDeleted == false)
                .AsNoTracking();
        }
    }
}