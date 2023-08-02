using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiErrorLogException : ArgumentException
    {
        public DuplicateAiErrorLogException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}