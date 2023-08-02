using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateEmployeeAddressException : ArgumentException
    {
        public DuplicateEmployeeAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}