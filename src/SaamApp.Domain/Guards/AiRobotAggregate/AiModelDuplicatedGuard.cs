using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AiModelGuardExtensions
    {
        public static void DuplicateAiModel(this IGuardClause guardClause, IEnumerable<AiModel> existingAiModels,
            AiModel newAiModel, string parameterName)
        {
            if (existingAiModels.Any(a => a.AiModelId == newAiModel.AiModelId))
            {
                throw new DuplicateAiModelException("Cannot add duplicate aiModel.", parameterName);
            }
        }
    }
}