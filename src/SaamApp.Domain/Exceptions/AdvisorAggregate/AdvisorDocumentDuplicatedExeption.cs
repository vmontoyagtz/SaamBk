using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorDocumentException : ArgumentException
    {
        public DuplicateAdvisorDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}