using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTemplateDocumentException : ArgumentException
    {
        public DuplicateTemplateDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}