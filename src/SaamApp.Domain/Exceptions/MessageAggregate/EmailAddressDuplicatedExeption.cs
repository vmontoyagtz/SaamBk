using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateEmailAddressException : ArgumentException
    {
        public DuplicateEmailAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}