using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerAddressException : ArgumentException
    {
        public DuplicateCustomerAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}