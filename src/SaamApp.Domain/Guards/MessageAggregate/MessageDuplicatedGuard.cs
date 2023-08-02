using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class MessageGuardExtensions
    {
        public static void DuplicateMessage(this IGuardClause guardClause, IEnumerable<Message> existingMessages,
            Message newMessage, string parameterName)
        {
            if (existingMessages.Any(a => a.MessageId == newMessage.MessageId))
            {
                throw new DuplicateMessageException("Cannot add duplicate message.", parameterName);
            }
        }
    }
}