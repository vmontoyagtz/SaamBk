using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBusinessUnitPhoneNumberException : ArgumentException
    {
        public DuplicateBusinessUnitPhoneNumberException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}