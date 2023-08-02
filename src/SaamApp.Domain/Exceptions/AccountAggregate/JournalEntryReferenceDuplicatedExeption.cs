using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateJournalEntryReferenceException : ArgumentException
    {
        public DuplicateJournalEntryReferenceException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}