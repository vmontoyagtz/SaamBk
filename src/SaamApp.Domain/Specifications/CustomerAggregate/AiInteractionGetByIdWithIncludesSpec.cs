using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiInteractionByIdWithIncludesSpec : Specification<AiInteraction>, ISingleResultSpecification
    {
        public AiInteractionByIdWithIncludesSpec(Guid aiInteractionId)
        {
            Guard.Against.NullOrEmpty(aiInteractionId, nameof(aiInteractionId));
            Query.Where(aiInteraction => aiInteraction.AiInteractionId == aiInteractionId)
                .Include(a => a.AiRobot)
                .Include(b => b.Customer)
                .AsNoTracking();
        }
    }
}