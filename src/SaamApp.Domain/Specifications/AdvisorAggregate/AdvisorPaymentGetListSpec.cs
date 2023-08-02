using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorPaymentGetListSpec : Specification<AdvisorPayment>
    {
        public AdvisorPaymentGetListSpec()
        {
            Query.Where(advisorPayment => advisorPayment.IsDeleted == false)
                .AsNoTracking();
        }
    }
}