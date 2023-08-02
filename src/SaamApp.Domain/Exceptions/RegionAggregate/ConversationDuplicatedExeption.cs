using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateConversationException : ArgumentException
    {
        public DuplicateConversationException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}