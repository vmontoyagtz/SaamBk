using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiInteractionGuardExtensions
    {
        public static void DuplicateAiInteraction(this IGuardClause guardClause,
            IEnumerable<AiInteraction> existingAiInteractions, AiInteraction newAiInteraction, string parameterName)
        {
            if (existingAiInteractions.Any(a => a.AiInteractionId == newAiInteraction.AiInteractionId))
            {
                throw new DuplicateAiInteractionException("Cannot add duplicate aiInteraction.", parameterName);
            }
        }
    }
}