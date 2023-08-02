using System;

namespace SaamApp.Domain.Exceptions
{
    public class ConversationStageNotFoundException : Exception
    {
        public ConversationStageNotFoundException(string message) : base(message)
        {
        }

        public ConversationStageNotFoundException(Guid conversationStageId) : base(
            $"No conversationStage with id {conversationStageId} found.")
        {
        }
    }
}