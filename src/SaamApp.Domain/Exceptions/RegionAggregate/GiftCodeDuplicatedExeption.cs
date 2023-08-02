using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateGiftCodeException : ArgumentException
    {
        public DuplicateGiftCodeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}