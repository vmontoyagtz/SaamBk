using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerEmailAddressException : ArgumentException
    {
        public DuplicateCustomerEmailAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}