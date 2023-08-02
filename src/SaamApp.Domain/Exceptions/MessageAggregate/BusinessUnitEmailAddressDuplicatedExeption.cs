using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBusinessUnitEmailAddressException : ArgumentException
    {
        public DuplicateBusinessUnitEmailAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}