using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class SerfinsaPaymentGetListSpec : Specification<SerfinsaPayment>
    {
        public SerfinsaPaymentGetListSpec()
        {
            Query.Where(serfinsaPayment => serfinsaPayment.IsDeleted == false)
                .AsNoTracking();
        }
    }
}