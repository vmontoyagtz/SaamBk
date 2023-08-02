using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCategoryException : ArgumentException
    {
        public DuplicateCategoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}