using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class RegionGetListSpec : Specification<Region>
    {
        public RegionGetListSpec()
        {
            Query.OrderBy(region => region.RegionId)
                .AsNoTracking();
        }
    }
}