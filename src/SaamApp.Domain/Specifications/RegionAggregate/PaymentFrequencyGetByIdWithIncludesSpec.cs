using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PaymentFrequencyByIdWithIncludesSpec : Specification<PaymentFrequency>, ISingleResultSpecification
    {
        public PaymentFrequencyByIdWithIncludesSpec(Guid paymentFrequencyId)
        {
            Guard.Against.NullOrEmpty(paymentFrequencyId, nameof(paymentFrequencyId));
            Query.Where(paymentFrequency => paymentFrequency.PaymentFrequencyId == paymentFrequencyId)
                .Include(a => a.Advisors)
                .ThenInclude(a => a.RegionAreaAdvisorCategories)
                .ThenInclude(a => a.Comissions)
                .AsNoTracking();
        }
    }
}