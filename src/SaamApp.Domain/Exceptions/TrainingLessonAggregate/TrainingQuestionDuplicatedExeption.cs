using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTrainingQuestionException : ArgumentException
    {
        public DuplicateTrainingQuestionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}