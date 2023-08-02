using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTaxpayerTypeException : ArgumentException
    {
        public DuplicateTaxpayerTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}