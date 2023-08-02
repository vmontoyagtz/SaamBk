using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorPaymentWithPaymentMethodKeySpec : Specification<AdvisorPayment>
    {
        public GetAdvisorPaymentWithPaymentMethodKeySpec(Guid paymentMethodId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Query.Where(ap => ap.PaymentMethodId == paymentMethodId).AsNoTracking();
        }
    }

    public class GetCustomerPaymentWithPaymentMethodKeySpec : Specification<CustomerPayment>
    {
        public GetCustomerPaymentWithPaymentMethodKeySpec(Guid paymentMethodId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Query.Where(cp => cp.PaymentMethodId == paymentMethodId).AsNoTracking();
        }
    }
}