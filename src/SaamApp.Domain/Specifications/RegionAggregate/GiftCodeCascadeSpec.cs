using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetGiftCodeRedemptionWithGiftCodeKeySpec : Specification<GiftCodeRedemption>
    {
        public GetGiftCodeRedemptionWithGiftCodeKeySpec(Guid giftCodeId)
        {
            Guard.Against.NullOrEmpty(giftCodeId, nameof(giftCodeId));
            Query.Where(gcr => gcr.GiftCodeId == giftCodeId).AsNoTracking();
        }
    }
}