using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class JournalEntryLineGuardExtensions
    {
        public static void DuplicateJournalEntryLine(this IGuardClause guardClause,
            IEnumerable<JournalEntryLine> existingJournalEntryLines, JournalEntryLine newJournalEntryLine,
            string parameterName)
        {
            if (existingJournalEntryLines.Any(a => a.JournalEntryLineId == newJournalEntryLine.JournalEntryLineId))
            {
                throw new DuplicateJournalEntryLineException("Cannot add duplicate journalEntryLine.", parameterName);
            }
        }
    }
}