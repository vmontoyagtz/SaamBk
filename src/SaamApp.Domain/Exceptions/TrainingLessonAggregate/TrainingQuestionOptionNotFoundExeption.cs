using System;

namespace SaamApp.Domain.Exceptions
{
    public class TrainingQuestionOptionNotFoundException : Exception
    {
        public TrainingQuestionOptionNotFoundException(string message) : base(message)
        {
        }

        public TrainingQuestionOptionNotFoundException(Guid trainingQuestionOptionId) : base(
            $"No trainingQuestionOption with id {trainingQuestionOptionId} found.")
        {
        }
    }
}