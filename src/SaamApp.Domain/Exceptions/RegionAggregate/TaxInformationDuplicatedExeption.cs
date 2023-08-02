using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTaxInformationException : ArgumentException
    {
        public DuplicateTaxInformationException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}