using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class JournalEntryReferenceGuardExtensions
    {
        public static void DuplicateJournalEntryReference(this IGuardClause guardClause,
            IEnumerable<JournalEntryReference> existingJournalEntryReferences,
            JournalEntryReference newJournalEntryReference, string parameterName)
        {
            if (existingJournalEntryReferences.Any(a => a.RowId == newJournalEntryReference.RowId))
            {
                throw new DuplicateJournalEntryReferenceException("Cannot add duplicate journalEntryReference.",
                    parameterName);
            }
        }
    }
}