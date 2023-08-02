using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateGiftCodeRedemptionException : ArgumentException
    {
        public DuplicateGiftCodeRedemptionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}