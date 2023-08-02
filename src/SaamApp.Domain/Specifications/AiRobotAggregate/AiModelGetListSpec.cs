using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiModelGetListSpec : Specification<AiModel>
    {
        public AiModelGetListSpec()
        {
            Query.Where(aiModel => aiModel.IsActive == true)
                .OrderBy(aiModel => aiModel.ModelName)
                .AsNoTracking();
        }
    }
}