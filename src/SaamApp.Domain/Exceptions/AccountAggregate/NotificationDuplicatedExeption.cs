using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateNotificationException : ArgumentException
    {
        public DuplicateNotificationException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}