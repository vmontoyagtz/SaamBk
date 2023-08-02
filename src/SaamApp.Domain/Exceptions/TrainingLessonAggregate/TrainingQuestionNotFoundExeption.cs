using System;

namespace SaamApp.Domain.Exceptions
{
    public class TrainingQuestionNotFoundException : Exception
    {
        public TrainingQuestionNotFoundException(string message) : base(message)
        {
        }

        public TrainingQuestionNotFoundException(Guid trainingQuestionId) : base(
            $"No trainingQuestion with id {trainingQuestionId} found.")
        {
        }
    }
}