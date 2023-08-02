using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateMessageDocumentException : ArgumentException
    {
        public DuplicateMessageDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}