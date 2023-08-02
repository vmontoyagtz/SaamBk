using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicatePrepaidPackageRedemptionException : ArgumentException
    {
        public DuplicatePrepaidPackageRedemptionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}