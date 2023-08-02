using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiAreaExpertiseException : ArgumentException
    {
        public DuplicateAiAreaExpertiseException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}