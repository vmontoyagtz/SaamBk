using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateGenderException : ArgumentException
    {
        public DuplicateGenderException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}