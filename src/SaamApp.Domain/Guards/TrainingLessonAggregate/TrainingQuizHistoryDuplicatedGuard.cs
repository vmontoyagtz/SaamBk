using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TrainingQuizHistoryGuardExtensions
    {
        public static void DuplicateTrainingQuizHistory(this IGuardClause guardClause,
            IEnumerable<TrainingQuizHistory> existingTrainingQuizHistories, TrainingQuizHistory newTrainingQuizHistory,
            string parameterName)
        {
            if (existingTrainingQuizHistories.Any(a =>
                    a.TrainingQuizHistoryId == newTrainingQuizHistory.TrainingQuizHistoryId))
            {
                throw new DuplicateTrainingQuizHistoryException("Cannot add duplicate trainingQuizHistory.",
                    parameterName);
            }
        }
    }
}