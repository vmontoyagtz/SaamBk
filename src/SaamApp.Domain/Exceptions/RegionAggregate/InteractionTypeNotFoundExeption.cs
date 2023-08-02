using System;

namespace SaamApp.Domain.Exceptions
{
    public class InteractionTypeNotFoundException : Exception
    {
        public InteractionTypeNotFoundException(string message) : base(message)
        {
        }

        public InteractionTypeNotFoundException(Guid interactionTypeId) : base(
            $"No interactionType with id {interactionTypeId} found.")
        {
        }
    }
}