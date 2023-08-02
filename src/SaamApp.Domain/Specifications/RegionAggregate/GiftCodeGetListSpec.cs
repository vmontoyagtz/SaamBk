using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GiftCodeGetListSpec : Specification<GiftCode>
    {
        public GiftCodeGetListSpec()
        {
            Query.Where(giftCode => giftCode.IsDeleted == false)
                .AsNoTracking();
        }
    }
}