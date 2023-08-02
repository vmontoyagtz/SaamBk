using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiRobotGuardExtensions
    {
        public static void DuplicateAiRobot(this IGuardClause guardClause, IEnumerable<AiRobot> existingAiRobots,
            AiRobot newAiRobot, string parameterName)
        {
            if (existingAiRobots.Any(a => a.AiRobotId == newAiRobot.AiRobotId))
            {
                throw new DuplicateAiRobotException("Cannot add duplicate aiRobot.", parameterName);
            }
        }
    }
}