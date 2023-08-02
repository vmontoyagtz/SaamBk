using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetJournalEntryLineWithJournalEntryKeySpec : Specification<JournalEntryLine>
    {
        public GetJournalEntryLineWithJournalEntryKeySpec(Guid journalEntryId)
        {
            Guard.Against.NullOrEmpty(journalEntryId, nameof(journalEntryId));
            Query.Where(jel => jel.JournalEntryId == journalEntryId).AsNoTracking();
        }
    }
}