using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateDiscountCodeException : ArgumentException
    {
        public DuplicateDiscountCodeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}