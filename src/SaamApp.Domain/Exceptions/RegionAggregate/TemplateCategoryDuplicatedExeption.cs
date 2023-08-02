using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateTemplateCategoryException : ArgumentException
    {
        public DuplicateTemplateCategoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}