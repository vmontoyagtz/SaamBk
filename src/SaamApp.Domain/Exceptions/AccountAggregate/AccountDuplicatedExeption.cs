using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAccountException : ArgumentException
    {
        public DuplicateAccountException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}