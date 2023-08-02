using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorCustomerException : ArgumentException
    {
        public DuplicateAdvisorCustomerException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}