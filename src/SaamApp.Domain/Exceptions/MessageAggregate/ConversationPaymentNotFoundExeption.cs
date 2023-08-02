using System;

namespace SaamApp.Domain.Exceptions
{
    public class ConversationPaymentNotFoundException : Exception
    {
        public ConversationPaymentNotFoundException(string message) : base(message)
        {
        }

        public ConversationPaymentNotFoundException(int rowId) : base($"No conversationPayment with id {rowId} found.")
        {
        }
    }
}