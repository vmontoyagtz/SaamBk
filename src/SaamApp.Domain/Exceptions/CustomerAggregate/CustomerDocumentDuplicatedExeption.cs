using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateCustomerDocumentException : ArgumentException
    {
        public DuplicateCustomerDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}