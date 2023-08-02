using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateConversationPaymentException : ArgumentException
    {
        public DuplicateConversationPaymentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}