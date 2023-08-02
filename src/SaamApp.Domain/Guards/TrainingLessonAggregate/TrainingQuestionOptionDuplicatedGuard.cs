using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TrainingQuestionOptionGuardExtensions
    {
        public static void DuplicateTrainingQuestionOption(this IGuardClause guardClause,
            IEnumerable<TrainingQuestionOption> existingTrainingQuestionOptions,
            TrainingQuestionOption newTrainingQuestionOption, string parameterName)
        {
            if (existingTrainingQuestionOptions.Any(a =>
                    a.TrainingQuestionOptionId == newTrainingQuestionOption.TrainingQuestionOptionId))
            {
                throw new DuplicateTrainingQuestionOptionException("Cannot add duplicate trainingQuestionOption.",
                    parameterName);
            }
        }
    }
}