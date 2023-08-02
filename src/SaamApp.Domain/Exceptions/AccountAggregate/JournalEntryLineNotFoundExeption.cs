using System;

namespace SaamApp.Domain.Exceptions
{
    public class JournalEntryLineNotFoundException : Exception
    {
        public JournalEntryLineNotFoundException(string message) : base(message)
        {
        }

        public JournalEntryLineNotFoundException(Guid journalEntryLineId) : base(
            $"No journalEntryLine with id {journalEntryLineId} found.")
        {
        }
    }
}