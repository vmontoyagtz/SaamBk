using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerException : ArgumentException
    {
        public DuplicateCustomerException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}