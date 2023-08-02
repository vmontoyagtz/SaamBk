using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class PrepaidPackageGetListSpec : Specification<PrepaidPackage>
    {
        public PrepaidPackageGetListSpec()
        {
            Query.Where(prepaidPackage => prepaidPackage.PrepaidPackageIsActive == true)
                .AsNoTracking();
        }
    }
}