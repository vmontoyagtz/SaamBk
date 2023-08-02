using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAddressException : ArgumentException
    {
        public DuplicateAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}