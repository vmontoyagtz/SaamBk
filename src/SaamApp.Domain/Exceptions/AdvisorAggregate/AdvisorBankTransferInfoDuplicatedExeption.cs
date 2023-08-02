using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorBankTransferInfoException : ArgumentException
    {
        public DuplicateAdvisorBankTransferInfoException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}