using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class RegionAreaAdvisorCategoryGetListSpec : Specification<RegionAreaAdvisorCategory>
    {
        public RegionAreaAdvisorCategoryGetListSpec()
        {
            Query.OrderBy(regionAreaAdvisorCategory => regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId)
                .AsNoTracking();
        }
    }
}