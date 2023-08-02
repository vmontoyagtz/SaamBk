using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerPaymentException : ArgumentException
    {
        public DuplicateCustomerPaymentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}