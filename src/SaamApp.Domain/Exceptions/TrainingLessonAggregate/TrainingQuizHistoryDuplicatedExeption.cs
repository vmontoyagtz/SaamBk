using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTrainingQuizHistoryException : ArgumentException
    {
        public DuplicateTrainingQuizHistoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}