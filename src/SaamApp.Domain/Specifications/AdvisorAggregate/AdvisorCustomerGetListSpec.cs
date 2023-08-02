using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorCustomerGetListSpec : Specification<AdvisorCustomer>
    {
        public AdvisorCustomerGetListSpec()
        {
            Query.OrderBy(advisorCustomer => advisorCustomer.RowId)
                .AsNoTracking();
        }
    }
}