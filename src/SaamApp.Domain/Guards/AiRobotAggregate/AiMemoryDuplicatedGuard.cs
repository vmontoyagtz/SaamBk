using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiMemoryGuardExtensions
    {
        public static void DuplicateAiMemory(this IGuardClause guardClause, IEnumerable<AiMemory> existingAiMemories,
            AiMemory newAiMemory, string parameterName)
        {
            if (existingAiMemories.Any(a => a.AiMemoryId == newAiMemory.AiMemoryId))
            {
                throw new DuplicateAiMemoryException("Cannot add duplicate aiMemory.", parameterName);
            }
        }
    }
}