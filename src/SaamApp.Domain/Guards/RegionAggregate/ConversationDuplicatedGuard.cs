using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class ConversationGuardExtensions
    {
        public static void DuplicateConversation(this IGuardClause guardClause,
            IEnumerable<Conversation> existingConversations, Conversation newConversation, string parameterName)
        {
            if (existingConversations.Any(a => a.ConversationId == newConversation.ConversationId))
            {
                throw new DuplicateConversationException("Cannot add duplicate conversation.", parameterName);
            }
        }
    }
}