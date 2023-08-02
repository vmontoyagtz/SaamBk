using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBankAccountException : ArgumentException
    {
        public DuplicateBankAccountException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}