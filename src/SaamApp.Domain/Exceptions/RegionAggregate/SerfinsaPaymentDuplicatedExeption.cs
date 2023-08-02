using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateSerfinsaPaymentException : ArgumentException
    {
        public DuplicateSerfinsaPaymentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}