using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTrainingQuestionOptionException : ArgumentException
    {
        public DuplicateTrainingQuestionOptionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}