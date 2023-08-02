using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GiftCodeRedemptionGetListSpec : Specification<GiftCodeRedemption>
    {
        public GiftCodeRedemptionGetListSpec()
        {
            Query.OrderBy(giftCodeRedemption => giftCodeRedemption.GiftCodeRedemptionId)
                .AsNoTracking();
        }
    }
}