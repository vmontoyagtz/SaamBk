using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateEmailAddressTypeException : ArgumentException
    {
        public DuplicateEmailAddressTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}