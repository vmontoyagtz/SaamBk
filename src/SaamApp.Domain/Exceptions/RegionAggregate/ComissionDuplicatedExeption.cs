using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateComissionException : ArgumentException
    {
        public DuplicateComissionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}