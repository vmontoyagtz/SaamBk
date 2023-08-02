using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiSessionGuardExtensions
    {
        public static void DuplicateAiSession(this IGuardClause guardClause, IEnumerable<AiSession> existingAiSessions,
            AiSession newAiSession, string parameterName)
        {
            if (existingAiSessions.Any(a => a.AiSessionId == newAiSession.AiSessionId))
            {
                throw new DuplicateAiSessionException("Cannot add duplicate aiSession.", parameterName);
            }
        }
    }
}