using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBusinessUnitAddressException : ArgumentException
    {
        public DuplicateBusinessUnitAddressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}