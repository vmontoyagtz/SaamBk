using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorEmailAddressException : ArgumentException
    {
        public DuplicateAdvisorEmailAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}