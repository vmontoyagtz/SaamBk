using System;

namespace SaamApp.Domain.Exceptions
{
    public class CustomerAiHistoryNotFoundException : Exception
    {
        public CustomerAiHistoryNotFoundException(string message) : base(message)
        {
        }

        public CustomerAiHistoryNotFoundException(Guid customerAiHistoryId) : base(
            $"No customerAiHistory with id {customerAiHistoryId} found.")
        {
        }
    }
}