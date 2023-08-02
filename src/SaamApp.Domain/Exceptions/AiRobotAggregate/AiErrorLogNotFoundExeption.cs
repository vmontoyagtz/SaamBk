using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiErrorLogNotFoundException : Exception
    {
        public AiErrorLogNotFoundException(string message) : base(message)
        {
        }

        public AiErrorLogNotFoundException(Guid aiErrorLogId) : base($"No aiErrorLog with id {aiErrorLogId} found.")
        {
        }
    }
}