using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateEmployeeEmailAddressException : ArgumentException
    {
        public DuplicateEmployeeEmailAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}