using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateInvoiceDetailException : ArgumentException
    {
        public DuplicateInvoiceDetailException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}