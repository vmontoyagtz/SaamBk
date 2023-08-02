using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateJournalEntryLineException : ArgumentException
    {
        public DuplicateJournalEntryLineException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}