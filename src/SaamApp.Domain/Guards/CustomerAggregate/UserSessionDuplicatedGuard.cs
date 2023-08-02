using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class UserSessionGuardExtensions
    {
        public static void DuplicateUserSession(this IGuardClause guardClause,
            IEnumerable<UserSession> existingUserSessions, UserSession newUserSession, string parameterName)
        {
            if (existingUserSessions.Any(a => a.SessionId == newUserSession.SessionId))
            {
                throw new DuplicateUserSessionException("Cannot add duplicate userSession.", parameterName);
            }
        }
    }
}