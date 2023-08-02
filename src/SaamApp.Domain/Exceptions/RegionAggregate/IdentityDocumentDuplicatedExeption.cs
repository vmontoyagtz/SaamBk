using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateIdentityDocumentException : ArgumentException
    {
        public DuplicateIdentityDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}