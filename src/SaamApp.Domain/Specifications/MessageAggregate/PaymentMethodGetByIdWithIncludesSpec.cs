using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PaymentMethodByIdWithIncludesSpec : Specification<PaymentMethod>, ISingleResultSpecification
    {
        public PaymentMethodByIdWithIncludesSpec(Guid paymentMethodId)
        {
            Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            Query.Where(paymentMethod => paymentMethod.PaymentMethodId == paymentMethodId)
                .Include(a => a.AdvisorPayments)
                .ThenInclude(b => b.Advisor).Include(b => b.AdvisorPayments).ThenInclude(b => b.BankAccount)
                .Include(b => b.CustomerPayments)
                .ThenInclude(c => c.SerfinsaPayment)
                .AsNoTracking();
        }
    }
}