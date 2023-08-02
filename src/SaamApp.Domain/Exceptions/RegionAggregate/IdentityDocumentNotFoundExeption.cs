using System;

namespace SaamApp.Domain.Exceptions
{
    public class IdentityDocumentNotFoundException : Exception
    {
        public IdentityDocumentNotFoundException(string message) : base(message)
        {
        }

        public IdentityDocumentNotFoundException(Guid identityDocumentId) : base(
            $"No identityDocument with id {identityDocumentId} found.")
        {
        }
    }
}