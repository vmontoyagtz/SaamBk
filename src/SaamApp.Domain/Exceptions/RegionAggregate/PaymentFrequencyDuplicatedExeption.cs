using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicatePaymentFrequencyException : ArgumentException
    {
        public DuplicatePaymentFrequencyException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}