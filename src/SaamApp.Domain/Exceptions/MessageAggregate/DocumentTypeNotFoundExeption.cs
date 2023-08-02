using System;

namespace SaamApp.Domain.Exceptions
{
    public class DocumentTypeNotFoundException : Exception
    {
        public DocumentTypeNotFoundException(string message) : base(message)
        {
        }

        public DocumentTypeNotFoundException(Guid documentTypeId) : base(
            $"No documentType with id {documentTypeId} found.")
        {
        }
    }
}