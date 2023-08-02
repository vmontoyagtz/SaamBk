using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicatePhoneNumberTypeException : ArgumentException
    {
        public DuplicatePhoneNumberTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}