using System;

namespace SaamApp.Domain.Exceptions
{
    public class ConversationNotFoundException : Exception
    {
        public ConversationNotFoundException(string message) : base(message)
        {
        }

        public ConversationNotFoundException(Guid conversationId) : base(
            $"No conversation with id {conversationId} found.")
        {
        }
    }
}