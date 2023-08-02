using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class SerfinsaPaymentByIdWithIncludesSpec : Specification<SerfinsaPayment>, ISingleResultSpecification
    {
        public SerfinsaPaymentByIdWithIncludesSpec(Guid serfinsaPaymentId)
        {
            Guard.Against.NullOrEmpty(serfinsaPaymentId, nameof(serfinsaPaymentId));
            Query.Where(serfinsaPayment => serfinsaPayment.SerfinsaPaymentId == serfinsaPaymentId)
                .Include(a => a.Customer)
                .Include(b => b.DiscountCode)
                .Include(c => c.PrepaidPackage)
                .Include(d => d.CustomerPayments)
                .ThenInclude(e => e.PaymentMethod)
                .AsNoTracking();
        }
    }
}