using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateUnansweredConversationException : ArgumentException
    {
        public DuplicateUnansweredConversationException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}