using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiSessionGetListSpec : Specification<AiSession>
    {
        public AiSessionGetListSpec()
        {
            Query.OrderBy(aiSession => aiSession.AiSessionId)
                .AsNoTracking();
        }
    }
}