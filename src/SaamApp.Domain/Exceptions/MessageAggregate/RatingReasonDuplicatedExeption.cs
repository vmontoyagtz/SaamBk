using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateRatingReasonException : ArgumentException
    {
        public DuplicateRatingReasonException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}