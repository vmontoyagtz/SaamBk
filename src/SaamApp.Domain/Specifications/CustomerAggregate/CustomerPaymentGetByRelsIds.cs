using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerPaymentByRelIdsSpec : Specification<CustomerPayment>
    {
        public CustomerPaymentByRelIdsSpec(Guid paymentMethodId, Guid serfinsaPaymentId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            Query.Where(customerPayment => customerPayment.PaymentMethodId == paymentMethodId &&
                                           customerPayment.SerfinsaPaymentId == serfinsaPaymentId &&
                                           customerPayment.TenantId == tenantId).AsNoTracking();
        }
    }
}