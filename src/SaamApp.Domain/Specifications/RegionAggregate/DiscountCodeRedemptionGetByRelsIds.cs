using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class DiscountCodeRedemptionByRelIdsSpec : Specification<DiscountCodeRedemption>
    {
        public DiscountCodeRedemptionByRelIdsSpec(DateTime discountCodeRedemptionDate, Guid customerId,
            Guid discountCodeId)
        {
            Guard.Against.OutOfSQLDateRange(discountCodeRedemptionDate, nameof(discountCodeRedemptionDate));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            Query.Where(discountCodeRedemption =>
                discountCodeRedemption.DiscountCodeRedemptionDate == discountCodeRedemptionDate &&
                discountCodeRedemption.CustomerId == customerId &&
                discountCodeRedemption.DiscountCodeId == discountCodeId).AsNoTracking();
        }
    }
}