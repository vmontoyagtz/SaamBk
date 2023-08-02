using System;

namespace SaamApp.Domain.Exceptions
{
    public class MessageDocumentNotFoundException : Exception
    {
        public MessageDocumentNotFoundException(string message) : base(message)
        {
        }

        public MessageDocumentNotFoundException(int rowId) : base($"No messageDocument with id {rowId} found.")
        {
        }
    }
}