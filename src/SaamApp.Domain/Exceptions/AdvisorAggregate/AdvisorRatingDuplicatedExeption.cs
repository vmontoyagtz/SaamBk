using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorRatingException : ArgumentException
    {
        public DuplicateAdvisorRatingException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}