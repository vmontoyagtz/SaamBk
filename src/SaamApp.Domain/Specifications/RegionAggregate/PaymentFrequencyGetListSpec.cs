using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PaymentFrequencyGetListSpec : Specification<PaymentFrequency>
    {
        public PaymentFrequencyGetListSpec()
        {
            Query.OrderBy(paymentFrequency => paymentFrequency.PaymentFrequencyId)
                .AsNoTracking();
        }
    }
}