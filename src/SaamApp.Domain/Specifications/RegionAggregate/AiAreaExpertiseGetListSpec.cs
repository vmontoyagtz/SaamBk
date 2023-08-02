using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiAreaExpertiseGetListSpec : Specification<AiAreaExpertise>
    {
        public AiAreaExpertiseGetListSpec()
        {
            Query.OrderBy(aiAreaExpertise => aiAreaExpertise.RowId)
                .AsNoTracking();
        }
    }
}