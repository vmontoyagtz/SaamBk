using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCityException : ArgumentException
    {
        public DuplicateCityException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}