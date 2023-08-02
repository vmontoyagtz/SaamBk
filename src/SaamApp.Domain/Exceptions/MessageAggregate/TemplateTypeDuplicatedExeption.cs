using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTemplateTypeException : ArgumentException
    {
        public DuplicateTemplateTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}