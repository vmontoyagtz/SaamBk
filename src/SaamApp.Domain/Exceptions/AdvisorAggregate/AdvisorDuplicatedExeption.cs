using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorException : ArgumentException
    {
        public DuplicateAdvisorException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}