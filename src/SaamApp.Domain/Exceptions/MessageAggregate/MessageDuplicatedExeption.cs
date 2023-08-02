using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateMessageException : ArgumentException
    {
        public DuplicateMessageException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}