using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorAddressException : ArgumentException
    {
        public DuplicateAdvisorAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}