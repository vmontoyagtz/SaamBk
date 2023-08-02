using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBankException : ArgumentException
    {
        public DuplicateBankException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}