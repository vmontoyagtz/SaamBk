using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GiftCodeByIdWithIncludesSpec : Specification<GiftCode>, ISingleResultSpecification
    {
        public GiftCodeByIdWithIncludesSpec(Guid giftCodeId)
        {
            Guard.Against.NullOrEmpty(giftCodeId, nameof(giftCodeId));
            Query.Where(giftCode => giftCode.GiftCodeId == giftCodeId)
                .Include(a => a.Region)
                .Include(b => b.GiftCodeRedemptions)
                .ThenInclude(c => c.Customer)
                .AsNoTracking();
        }
    }
}