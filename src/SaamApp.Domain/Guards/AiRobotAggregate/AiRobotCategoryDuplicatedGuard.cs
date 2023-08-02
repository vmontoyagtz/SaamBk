using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiRobotCategoryGuardExtensions
    {
        public static void DuplicateAiRobotCategory(this IGuardClause guardClause,
            IEnumerable<AiRobotCategory> existingAiRobotCategories, AiRobotCategory newAiRobotCategory,
            string parameterName)
        {
            if (existingAiRobotCategories.Any(a => a.RowId == newAiRobotCategory.RowId))
            {
                throw new DuplicateAiRobotCategoryException("Cannot add duplicate aiRobotCategory.", parameterName);
            }
        }
    }
}