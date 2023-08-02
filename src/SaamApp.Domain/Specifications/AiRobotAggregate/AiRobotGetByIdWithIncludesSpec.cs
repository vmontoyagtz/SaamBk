using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiRobotByIdWithIncludesSpec : Specification<AiRobot>, ISingleResultSpecification
    {
        public AiRobotByIdWithIncludesSpec(Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            Query.Where(aiRobot => aiRobot.AiRobotId == aiRobotId)
                .Include(a => a.AiInteractions)
                .Include(b => b.AiRobotCategories)
                .ThenInclude(c => c.Comission).Include(c => c.AiRobotCategories)
                .ThenInclude(c => c.RegionAreaAdvisorCategory)
                .AsNoTracking();
        }
    }
}