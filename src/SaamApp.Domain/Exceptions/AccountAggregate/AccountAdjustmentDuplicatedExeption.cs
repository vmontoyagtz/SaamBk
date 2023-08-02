using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAccountAdjustmentException : ArgumentException
    {
        public DuplicateAccountAdjustmentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}