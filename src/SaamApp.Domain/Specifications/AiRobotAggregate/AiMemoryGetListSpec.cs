using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiMemoryGetListSpec : Specification<AiMemory>
    {
        public AiMemoryGetListSpec()
        {
            Query.OrderBy(aiMemory => aiMemory.AiMemoryId)
                .AsNoTracking();
        }
    }
}