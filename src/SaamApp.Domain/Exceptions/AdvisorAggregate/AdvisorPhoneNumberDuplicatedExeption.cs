using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorPhoneNumberException : ArgumentException
    {
        public DuplicateAdvisorPhoneNumberException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}