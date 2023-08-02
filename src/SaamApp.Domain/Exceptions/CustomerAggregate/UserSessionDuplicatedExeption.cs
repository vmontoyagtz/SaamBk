using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateUserSessionException : ArgumentException
    {
        public DuplicateUserSessionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}