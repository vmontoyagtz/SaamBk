using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerFeedbackException : ArgumentException
    {
        public DuplicateCustomerFeedbackException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}