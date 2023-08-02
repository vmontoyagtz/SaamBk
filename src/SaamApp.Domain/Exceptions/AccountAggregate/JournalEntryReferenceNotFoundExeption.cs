using System;

namespace SaamApp.Domain.Exceptions
{
    public class JournalEntryReferenceNotFoundException : Exception
    {
        public JournalEntryReferenceNotFoundException(string message) : base(message)
        {
        }

        public JournalEntryReferenceNotFoundException(int rowId) : base(
            $"No journalEntryReference with id {rowId} found.")
        {
        }
    }
}