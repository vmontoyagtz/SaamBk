using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAiInteractionWithAiRobotKeySpec : Specification<AiInteraction>
    {
        public GetAiInteractionWithAiRobotKeySpec(Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            Query.Where(ai => ai.AiRobotId == aiRobotId).AsNoTracking();
        }
    }

    public class GetAiRobotCategoryWithAiRobotKeySpec : Specification<AiRobotCategory>
    {
        public GetAiRobotCategoryWithAiRobotKeySpec(Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            Query.Where(arc => arc.AiRobotId == aiRobotId).AsNoTracking();
        }
    }
}