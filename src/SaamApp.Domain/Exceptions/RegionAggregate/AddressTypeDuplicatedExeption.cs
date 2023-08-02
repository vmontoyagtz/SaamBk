using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAddressTypeException : ArgumentException
    {
        public DuplicateAddressTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}