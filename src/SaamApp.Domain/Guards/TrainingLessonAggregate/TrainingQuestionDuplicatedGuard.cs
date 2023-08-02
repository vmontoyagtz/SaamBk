using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TrainingQuestionGuardExtensions
    {
        public static void DuplicateTrainingQuestion(this IGuardClause guardClause,
            IEnumerable<TrainingQuestion> existingTrainingQuestions, TrainingQuestion newTrainingQuestion,
            string parameterName)
        {
            if (existingTrainingQuestions.Any(a => a.TrainingQuestionId == newTrainingQuestion.TrainingQuestionId))
            {
                throw new DuplicateTrainingQuestionException("Cannot add duplicate trainingQuestion.", parameterName);
            }
        }
    }
}