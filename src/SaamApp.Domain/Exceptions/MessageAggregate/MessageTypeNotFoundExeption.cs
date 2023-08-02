using System;

namespace SaamApp.Domain.Exceptions
{
    public class MessageTypeNotFoundException : Exception
    {
        public MessageTypeNotFoundException(string message) : base(message)
        {
        }

        public MessageTypeNotFoundException(Guid messageTypeId) : base($"No messageType with id {messageTypeId} found.")
        {
        }
    }
}