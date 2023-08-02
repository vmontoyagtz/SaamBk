using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerReviewException : ArgumentException
    {
        public DuplicateCustomerReviewException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}