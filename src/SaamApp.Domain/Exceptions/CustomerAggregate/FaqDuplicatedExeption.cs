using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateFaqException : ArgumentException
    {
        public DuplicateFaqException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}