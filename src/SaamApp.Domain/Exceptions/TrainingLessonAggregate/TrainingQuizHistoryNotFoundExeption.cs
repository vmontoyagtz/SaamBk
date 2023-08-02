using System;

namespace SaamApp.Domain.Exceptions
{
    public class TrainingQuizHistoryNotFoundException : Exception
    {
        public TrainingQuizHistoryNotFoundException(string message) : base(message)
        {
        }

        public TrainingQuizHistoryNotFoundException(Guid trainingQuizHistoryId) : base(
            $"No trainingQuizHistory with id {trainingQuizHistoryId} found.")
        {
        }
    }
}