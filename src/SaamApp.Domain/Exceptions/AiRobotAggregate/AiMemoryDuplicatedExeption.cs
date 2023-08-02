using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiMemoryException : ArgumentException
    {
        public DuplicateAiMemoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}