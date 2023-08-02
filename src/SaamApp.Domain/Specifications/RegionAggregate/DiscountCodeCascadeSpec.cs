using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetDiscountCodeRedemptionWithDiscountCodeKeySpec : Specification<DiscountCodeRedemption>
    {
        public GetDiscountCodeRedemptionWithDiscountCodeKeySpec(Guid discountCodeId)
        {
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            Query.Where(dcr => dcr.DiscountCodeId == discountCodeId).AsNoTracking();
        }
    }

    public class GetSerfinsaPaymentWithDiscountCodeKeySpec : Specification<SerfinsaPayment>
    {
        public GetSerfinsaPaymentWithDiscountCodeKeySpec(Guid discountCodeId)
        {
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            Query.Where(sp => sp.DiscountCodeId == discountCodeId).AsNoTracking();
        }
    }
}