using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiInteractionException : ArgumentException
    {
        public DuplicateAiInteractionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}