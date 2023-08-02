using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetCustomerPaymentWithSerfinsaPaymentKeySpec : Specification<CustomerPayment>
    {
        public GetCustomerPaymentWithSerfinsaPaymentKeySpec(Guid serfinsaPaymentId)
        {
            Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            Query.Where(cp => cp.SerfinsaPaymentId == serfinsaPaymentId).AsNoTracking();
        }
    }
}