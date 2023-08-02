using System;

namespace SaamApp.Domain.Exceptions
{
    public class InvoiceNotFoundException : Exception
    {
        public InvoiceNotFoundException(string message) : base(message)
        {
        }

        public InvoiceNotFoundException(Guid invoiceId) : base($"No invoice with id {invoiceId} found.")
        {
        }
    }
}