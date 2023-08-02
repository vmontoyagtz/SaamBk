using System;

namespace SaamApp.Domain.Exceptions
{
    public class GenderNotFoundException : Exception
    {
        public GenderNotFoundException(string message) : base(message)
        {
        }

        public GenderNotFoundException(Guid genderId) : base($"No gender with id {genderId} found.")
        {
        }
    }
}