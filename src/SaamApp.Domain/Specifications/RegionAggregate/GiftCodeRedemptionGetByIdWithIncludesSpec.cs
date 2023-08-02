using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GiftCodeRedemptionByIdWithIncludesSpec : Specification<GiftCodeRedemption>, ISingleResultSpecification
    {
        public GiftCodeRedemptionByIdWithIncludesSpec(Guid giftCodeRedemptionId)
        {
            Guard.Against.NullOrEmpty(giftCodeRedemptionId, nameof(giftCodeRedemptionId));
            Query.Where(giftCodeRedemption => giftCodeRedemption.GiftCodeRedemptionId == giftCodeRedemptionId)
                .Include(a => a.Customer)
                .Include(b => b.GiftCode)
                .AsNoTracking();
        }
    }
}