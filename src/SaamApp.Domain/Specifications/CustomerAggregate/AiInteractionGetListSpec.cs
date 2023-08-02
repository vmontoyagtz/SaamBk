using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiInteractionGetListSpec : Specification<AiInteraction>
    {
        public AiInteractionGetListSpec()
        {
            Query.Where(aiInteraction => aiInteraction.IsSuccessful == true)
                .AsNoTracking();
        }
    }
}