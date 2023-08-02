using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiRobotCategoryByRelIdsSpec : Specification<AiRobotCategory>
    {
        public AiRobotCategoryByRelIdsSpec(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));
            Query.Where(aiRobotCategory => aiRobotCategory.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId &&
                                           aiRobotCategory.ComissionId == comissionId &&
                                           aiRobotCategory.AiRobotId == aiRobotId).AsNoTracking();
        }
    }
}