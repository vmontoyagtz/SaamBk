using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBusinessUnitException : ArgumentException
    {
        public DuplicateBusinessUnitException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}