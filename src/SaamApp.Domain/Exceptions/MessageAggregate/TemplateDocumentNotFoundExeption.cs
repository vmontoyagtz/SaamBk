using System;

namespace SaamApp.Domain.Exceptions
{
    public class TemplateDocumentNotFoundException : Exception
    {
        public TemplateDocumentNotFoundException(string message) : base(message)
        {
        }

        public TemplateDocumentNotFoundException(int rowId) : base($"No templateDocument with id {rowId} found.")
        {
        }
    }
}