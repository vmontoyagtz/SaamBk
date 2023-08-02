using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicatePrepaidPackageException : ArgumentException
    {
        public DuplicatePrepaidPackageException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}