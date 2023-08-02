using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TrainingProgressGuardExtensions
    {
        public static void DuplicateTrainingProgress(this IGuardClause guardClause,
            IEnumerable<TrainingProgress> existingTrainingProgresses, TrainingProgress newTrainingProgress,
            string parameterName)
        {
            if (existingTrainingProgresses.Any(a => a.TrainingProgressId == newTrainingProgress.TrainingProgressId))
            {
                throw new DuplicateTrainingProgressException("Cannot add duplicate trainingProgress.", parameterName);
            }
        }
    }
}