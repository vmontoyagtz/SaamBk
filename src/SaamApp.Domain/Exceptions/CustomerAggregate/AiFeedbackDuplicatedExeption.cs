using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiFeedbackException : ArgumentException
    {
        public DuplicateAiFeedbackException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}