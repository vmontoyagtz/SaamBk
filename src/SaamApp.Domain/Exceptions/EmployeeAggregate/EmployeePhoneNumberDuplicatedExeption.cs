using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateEmployeePhoneNumberException : ArgumentException
    {
        public DuplicateEmployeePhoneNumberException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}