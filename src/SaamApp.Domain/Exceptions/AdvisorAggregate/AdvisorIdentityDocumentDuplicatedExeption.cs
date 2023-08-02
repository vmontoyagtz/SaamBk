using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorIdentityDocumentException : ArgumentException
    {
        public DuplicateAdvisorIdentityDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}