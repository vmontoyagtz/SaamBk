using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicatePaymentMethodException : ArgumentException
    {
        public DuplicatePaymentMethodException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}