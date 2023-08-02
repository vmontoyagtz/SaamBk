using System;

namespace SaamApp.Domain.Exceptions
{
    public class CustomerDocumentNotFoundException : Exception
    {
        public CustomerDocumentNotFoundException(string message) : base(message)
        {
        }

        public CustomerDocumentNotFoundException(int rowId) : base($"No customerDocument with id {rowId} found.")
        {
        }
    }
}