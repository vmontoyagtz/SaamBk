using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateInteractionTypeException : ArgumentException
    {
        public DuplicateInteractionTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}