using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAccountAdjustmentRefException : ArgumentException
    {
        public DuplicateAccountAdjustmentRefException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}