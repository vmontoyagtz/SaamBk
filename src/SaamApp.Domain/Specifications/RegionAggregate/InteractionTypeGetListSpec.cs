using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class InteractionTypeGetListSpec : Specification<InteractionType>
    {
        public InteractionTypeGetListSpec()
        {
            Query.OrderBy(interactionType => interactionType.InteractionTypeId)
                .AsNoTracking();
        }
    }
}