using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications.Search
{
    public class AiModelSearchByModelName : Specification<AiModel>
    {
        public AiModelSearchByModelName(AiModelFilterModel filter)
        {
            if (!string.IsNullOrEmpty(filter.ModelName))
            {
                Query
                    .Search(x => x.ModelName, "%" + filter.ModelName + "%");
            }
        }
    }
}