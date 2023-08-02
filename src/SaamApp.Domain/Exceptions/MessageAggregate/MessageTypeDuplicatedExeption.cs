using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateMessageTypeException : ArgumentException
    {
        public DuplicateMessageTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}