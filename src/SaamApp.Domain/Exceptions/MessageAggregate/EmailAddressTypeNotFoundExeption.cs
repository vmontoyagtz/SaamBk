using System;

namespace SaamApp.Domain.Exceptions
{
    public class EmailAddressTypeNotFoundException : Exception
    {
        public EmailAddressTypeNotFoundException(string message) : base(message)
        {
        }

        public EmailAddressTypeNotFoundException(Guid emailAddressTypeId) : base(
            $"No emailAddressType with id {emailAddressTypeId} found.")
        {
        }
    }
}