using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorDocumentNotFoundException : Exception
    {
        public AdvisorDocumentNotFoundException(string message) : base(message)
        {
        }

        public AdvisorDocumentNotFoundException(int rowId) : base($"No advisorDocument with id {rowId} found.")
        {
        }
    }
}