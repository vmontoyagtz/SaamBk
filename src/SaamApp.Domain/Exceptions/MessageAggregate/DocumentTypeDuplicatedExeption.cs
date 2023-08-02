using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateDocumentTypeException : ArgumentException
    {
        public DuplicateDocumentTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}