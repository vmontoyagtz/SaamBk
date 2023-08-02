using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiSessionNotFoundException : Exception
    {
        public AiSessionNotFoundException(string message) : base(message)
        {
        }

        public AiSessionNotFoundException(Guid aiSessionId) : base($"No aiSession with id {aiSessionId} found.")
        {
        }
    }
}