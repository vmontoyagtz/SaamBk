using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PrepaidPackageRedemptionGetListSpec : Specification<PrepaidPackageRedemption>
    {
        public PrepaidPackageRedemptionGetListSpec()
        {
            Query.OrderBy(prepaidPackageRedemption => prepaidPackageRedemption.PrepaidPackageRedemptionId)
                .AsNoTracking();
        }
    }
}