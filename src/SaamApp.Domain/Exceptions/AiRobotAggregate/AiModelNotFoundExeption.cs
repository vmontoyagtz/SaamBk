using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiModelNotFoundException : Exception
    {
        public AiModelNotFoundException(string message) : base(message)
        {
        }

        public AiModelNotFoundException(Guid aiModelId) : base($"No aiModel with id {aiModelId} found.")
        {
        }
    }
}