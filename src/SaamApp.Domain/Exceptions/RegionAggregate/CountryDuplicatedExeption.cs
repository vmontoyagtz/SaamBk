using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCountryException : ArgumentException
    {
        public DuplicateCountryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}