using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class UnansweredConversationGuardExtensions
    {
        public static void DuplicateUnansweredConversation(this IGuardClause guardClause,
            IEnumerable<UnansweredConversation> existingUnansweredConversations,
            UnansweredConversation newUnansweredConversation, string parameterName)
        {
            if (existingUnansweredConversations.Any(a =>
                    a.UnansweredConversationId == newUnansweredConversation.UnansweredConversationId))
            {
                throw new DuplicateUnansweredConversationException("Cannot add duplicate unansweredConversation.",
                    parameterName);
            }
        }
    }
}