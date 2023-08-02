using System;

namespace SaamApp.Domain.Exceptions
{
    public class DocumentNotFoundException : Exception
    {
        public DocumentNotFoundException(string message) : base(message)
        {
        }

        public DocumentNotFoundException(Guid documentId) : base($"No document with id {documentId} found.")
        {
        }
    }
}