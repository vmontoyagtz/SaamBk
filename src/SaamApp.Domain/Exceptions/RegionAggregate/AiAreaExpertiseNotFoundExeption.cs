using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiAreaExpertiseNotFoundException : Exception
    {
        public AiAreaExpertiseNotFoundException(string message) : base(message)
        {
        }

        public AiAreaExpertiseNotFoundException(int rowId) : base($"No aiAreaExpertise with id {rowId} found.")
        {
        }
    }
}