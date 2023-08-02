using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorLoginException : ArgumentException
    {
        public DuplicateAdvisorLoginException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}