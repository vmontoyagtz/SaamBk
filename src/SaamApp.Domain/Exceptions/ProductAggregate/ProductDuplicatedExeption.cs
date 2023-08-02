using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateProductException : ArgumentException
    {
        public DuplicateProductException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}