using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerAiHistoryException : ArgumentException
    {
        public DuplicateCustomerAiHistoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}