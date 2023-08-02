using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class ConversationStageGuardExtensions
    {
        public static void DuplicateConversationStage(this IGuardClause guardClause,
            IEnumerable<ConversationStage> existingConversationStages, ConversationStage newConversationStage,
            string parameterName)
        {
            if (existingConversationStages.Any(a => a.ConversationStageId == newConversationStage.ConversationStageId))
            {
                throw new DuplicateConversationStageException("Cannot add duplicate conversationStage.", parameterName);
            }
        }
    }
}