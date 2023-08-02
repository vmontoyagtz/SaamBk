using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiErrorLogGuardExtensions
    {
        public static void DuplicateAiErrorLog(this IGuardClause guardClause,
            IEnumerable<AiErrorLog> existingAiErrorLogs, AiErrorLog newAiErrorLog, string parameterName)
        {
            if (existingAiErrorLogs.Any(a => a.AiErrorLogId == newAiErrorLog.AiErrorLogId))
            {
                throw new DuplicateAiErrorLogException("Cannot add duplicate aiErrorLog.", parameterName);
            }
        }
    }
}