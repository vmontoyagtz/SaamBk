using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiSessionException : ArgumentException
    {
        public DuplicateAiSessionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}