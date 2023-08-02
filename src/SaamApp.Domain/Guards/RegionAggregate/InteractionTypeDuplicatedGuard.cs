using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class InteractionTypeGuardExtensions
    {
        public static void DuplicateInteractionType(this IGuardClause guardClause,
            IEnumerable<InteractionType> existingInteractionTypes, InteractionType newInteractionType,
            string parameterName)
        {
            if (existingInteractionTypes.Any(a => a.InteractionTypeId == newInteractionType.InteractionTypeId))
            {
                throw new DuplicateInteractionTypeException("Cannot add duplicate interactionType.", parameterName);
            }
        }
    }
}