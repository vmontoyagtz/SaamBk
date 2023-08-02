using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AppConfigParamGetListSpec : Specification<AppConfigParam>
    {
        public AppConfigParamGetListSpec()
        {
            Query.Where(appConfigParam => appConfigParam.IsDeleted == false)
                .AsNoTracking();
        }
    }
}