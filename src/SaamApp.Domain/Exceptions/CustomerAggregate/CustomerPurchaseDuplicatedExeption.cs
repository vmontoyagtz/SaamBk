using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerPurchaseException : ArgumentException
    {
        public DuplicateCustomerPurchaseException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}