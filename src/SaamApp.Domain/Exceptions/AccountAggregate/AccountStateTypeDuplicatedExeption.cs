using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAccountStateTypeException : ArgumentException
    {
        public DuplicateAccountStateTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}