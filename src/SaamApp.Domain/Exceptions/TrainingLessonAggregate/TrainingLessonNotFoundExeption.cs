using System;

namespace SaamApp.Domain.Exceptions
{
    public class TrainingLessonNotFoundException : Exception
    {
        public TrainingLessonNotFoundException(string message) : base(message)
        {
        }

        public TrainingLessonNotFoundException(Guid trainingLessonId) : base(
            $"No trainingLesson with id {trainingLessonId} found.")
        {
        }
    }
}