using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorWithPaymentFrequencyKeySpec : Specification<Advisor>
    {
        public GetAdvisorWithPaymentFrequencyKeySpec(Guid paymentFrequencyId)
        {
            Guard.Against.NullOrEmpty(paymentFrequencyId, nameof(paymentFrequencyId));
            Query.Where(a => a.PaymentFrequencyId == paymentFrequencyId).AsNoTracking();
        }
    }
}