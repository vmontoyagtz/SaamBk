using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateConversationStageException : ArgumentException
    {
        public DuplicateConversationStageException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}