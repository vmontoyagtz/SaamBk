using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiRobotCategoryGetListSpec : Specification<AiRobotCategory>
    {
        public AiRobotCategoryGetListSpec()
        {
            Query.OrderBy(aiRobotCategory => aiRobotCategory.RowId)
                .AsNoTracking();
        }
    }
}