using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateDiscountCodeRedemptionException : ArgumentException
    {
        public DuplicateDiscountCodeRedemptionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}