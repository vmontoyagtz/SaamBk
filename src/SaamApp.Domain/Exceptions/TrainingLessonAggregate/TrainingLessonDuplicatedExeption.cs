using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTrainingLessonException : ArgumentException
    {
        public DuplicateTrainingLessonException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}