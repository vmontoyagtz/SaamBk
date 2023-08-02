using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PaymentMethodGetListSpec : Specification<PaymentMethod>
    {
        public PaymentMethodGetListSpec()
        {
            Query.OrderBy(paymentMethod => paymentMethod.PaymentMethodId)
                .AsNoTracking();
        }
    }
}