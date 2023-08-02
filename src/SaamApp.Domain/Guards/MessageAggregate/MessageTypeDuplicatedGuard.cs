using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class MessageTypeGuardExtensions
    {
        public static void DuplicateMessageType(this IGuardClause guardClause,
            IEnumerable<MessageType> existingMessageTypes, MessageType newMessageType, string parameterName)
        {
            if (existingMessageTypes.Any(a => a.MessageTypeId == newMessageType.MessageTypeId))
            {
                throw new DuplicateMessageTypeException("Cannot add duplicate messageType.", parameterName);
            }
        }
    }
}