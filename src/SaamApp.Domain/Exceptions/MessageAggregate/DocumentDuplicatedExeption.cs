using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateDocumentException : ArgumentException
    {
        public DuplicateDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}