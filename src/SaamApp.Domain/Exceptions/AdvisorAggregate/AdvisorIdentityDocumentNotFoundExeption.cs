using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorIdentityDocumentNotFoundException : Exception
    {
        public AdvisorIdentityDocumentNotFoundException(string message) : base(message)
        {
        }

        public AdvisorIdentityDocumentNotFoundException(int rowId) : base(
            $"No advisorIdentityDocument with id {rowId} found.")
        {
        }
    }
}