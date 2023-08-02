using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class JournalEntryGuardExtensions
    {
        public static void DuplicateJournalEntry(this IGuardClause guardClause,
            IEnumerable<JournalEntry> existingJournalEntries, JournalEntry newJournalEntry, string parameterName)
        {
            if (existingJournalEntries.Any(a => a.JournalEntryId == newJournalEntry.JournalEntryId))
            {
                throw new DuplicateJournalEntryException("Cannot add duplicate journalEntry.", parameterName);
            }
        }
    }
}