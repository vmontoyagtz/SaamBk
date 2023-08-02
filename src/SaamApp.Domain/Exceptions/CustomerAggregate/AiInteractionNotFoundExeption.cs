using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiInteractionNotFoundException : Exception
    {
        public AiInteractionNotFoundException(string message) : base(message)
        {
        }

        public AiInteractionNotFoundException(Guid aiInteractionId) : base(
            $"No aiInteraction with id {aiInteractionId} found.")
        {
        }
    }
}