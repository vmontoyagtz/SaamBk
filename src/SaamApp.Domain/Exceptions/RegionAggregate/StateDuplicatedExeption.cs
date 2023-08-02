using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateStateException : ArgumentException
    {
        public DuplicateStateException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}