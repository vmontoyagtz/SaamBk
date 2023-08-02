using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorBankException : ArgumentException
    {
        public DuplicateAdvisorBankException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}