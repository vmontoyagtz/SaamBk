using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateJournalEntryException : ArgumentException
    {
        public DuplicateJournalEntryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}