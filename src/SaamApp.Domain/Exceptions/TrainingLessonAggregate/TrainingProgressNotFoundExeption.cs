using System;

namespace SaamApp.Domain.Exceptions
{
    public class TrainingProgressNotFoundException : Exception
    {
        public TrainingProgressNotFoundException(string message) : base(message)
        {
        }

        public TrainingProgressNotFoundException(Guid trainingProgressId) : base(
            $"No trainingProgress with id {trainingProgressId} found.")
        {
        }
    }
}