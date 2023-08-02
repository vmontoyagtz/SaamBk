using System;

namespace SaamApp.Domain.Exceptions
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException(string message) : base(message)
        {
        }

        public MessageNotFoundException(Guid messageId) : base($"No message with id {messageId} found.")
        {
        }
    }
}