using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class DiscountCodeGetListSpec : Specification<DiscountCode>
    {
        public DiscountCodeGetListSpec()
        {
            Query.Where(discountCode => discountCode.IsDeleted == false)
                .AsNoTracking();
        }
    }
}