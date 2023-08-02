using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TrainingLessonGuardExtensions
    {
        public static void DuplicateTrainingLesson(this IGuardClause guardClause,
            IEnumerable<TrainingLesson> existingTrainingLessons, TrainingLesson newTrainingLesson, string parameterName)
        {
            if (existingTrainingLessons.Any(a => a.TrainingLessonId == newTrainingLesson.TrainingLessonId))
            {
                throw new DuplicateTrainingLessonException("Cannot add duplicate trainingLesson.", parameterName);
            }
        }
    }
}