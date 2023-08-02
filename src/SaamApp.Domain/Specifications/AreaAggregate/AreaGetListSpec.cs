using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AreaGetListSpec : Specification<Area>
    {
        public AreaGetListSpec()
        {
            Query.Where(area => area.AreaStage == true)
                .AsNoTracking();
        }
    }
}