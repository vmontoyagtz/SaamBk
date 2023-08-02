using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiAreaExpertiseGuardExtensions
    {
        public static void DuplicateAiAreaExpertise(this IGuardClause guardClause,
            IEnumerable<AiAreaExpertise> existingAiAreaExpertises, AiAreaExpertise newAiAreaExpertise,
            string parameterName)
        {
            if (existingAiAreaExpertises.Any(a => a.RowId == newAiAreaExpertise.RowId))
            {
                throw new DuplicateAiAreaExpertiseException("Cannot add duplicate aiAreaExpertise.", parameterName);
            }
        }
    }
}