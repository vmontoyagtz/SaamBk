using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAreaException : ArgumentException
    {
        public DuplicateAreaException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}