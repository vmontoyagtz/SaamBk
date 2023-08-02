using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBusinessUnitTypeException : ArgumentException
    {
        public DuplicateBusinessUnitTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}