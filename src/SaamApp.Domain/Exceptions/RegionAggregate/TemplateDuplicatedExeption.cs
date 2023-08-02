using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTemplateException : ArgumentException
    {
        public DuplicateTemplateException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}