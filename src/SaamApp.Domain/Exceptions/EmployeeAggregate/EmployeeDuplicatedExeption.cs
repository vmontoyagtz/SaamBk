using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateEmployeeException : ArgumentException
    {
        public DuplicateEmployeeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}