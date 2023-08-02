using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class DiscountCodeRedemptionGetListSpec : Specification<DiscountCodeRedemption>
    {
        public DiscountCodeRedemptionGetListSpec()
        {
            Query.OrderBy(discountCodeRedemption => discountCodeRedemption.RowId)
                .AsNoTracking();
        }
    }
}