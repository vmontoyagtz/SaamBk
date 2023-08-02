using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiMemoryNotFoundException : Exception
    {
        public AiMemoryNotFoundException(string message) : base(message)
        {
        }

        public AiMemoryNotFoundException(Guid aiMemoryId) : base($"No aiMemory with id {aiMemoryId} found.")
        {
        }
    }
}