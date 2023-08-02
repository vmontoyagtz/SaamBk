using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiModelException : ArgumentException
    {
        public DuplicateAiModelException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}