using System;

namespace SaamApp.Domain.Exceptions
{
    public class JournalEntryNotFoundException : Exception
    {
        public JournalEntryNotFoundException(string message) : base(message)
        {
        }

        public JournalEntryNotFoundException(Guid journalEntryId) : base(
            $"No journalEntry with id {journalEntryId} found.")
        {
        }
    }
}