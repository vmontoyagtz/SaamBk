using System;

namespace SaamApp.Domain.Exceptions
{
    public class UnansweredConversationNotFoundException : Exception
    {
        public UnansweredConversationNotFoundException(string message) : base(message)
        {
        }

        public UnansweredConversationNotFoundException(Guid unansweredConversationId) : base(
            $"No unansweredConversation with id {unansweredConversationId} found.")
        {
        }
    }
}