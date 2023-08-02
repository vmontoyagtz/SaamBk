using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTrainingProgressException : ArgumentException
    {
        public DuplicateTrainingProgressException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}