using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerAccountException : ArgumentException
    {
        public DuplicateCustomerAccountException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}