using System;

namespace SaamApp.Domain.Exceptions
{
    public class InvoiceDetailNotFoundException : Exception
    {
        public InvoiceDetailNotFoundException(string message) : base(message)
        {
        }

        public InvoiceDetailNotFoundException(Guid invoiceDetailId) : base(
            $"No invoiceDetail with id {invoiceDetailId} found.")
        {
        }
    }
}