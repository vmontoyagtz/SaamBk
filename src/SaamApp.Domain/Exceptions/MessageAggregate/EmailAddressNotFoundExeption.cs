using System;

namespace SaamApp.Domain.Exceptions
{
    public class EmailAddressNotFoundException : Exception
    {
        public EmailAddressNotFoundException(string message) : base(message)
        {
        }

        public EmailAddressNotFoundException(Guid emailAddressId) : base(
            $"No emailAddress with id {emailAddressId} found.")
        {
        }
    }
}