using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorPaymentException : ArgumentException
    {
        public DuplicateAdvisorPaymentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}