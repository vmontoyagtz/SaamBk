using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetJournalEntryReferenceWithJournalEntryLineKeySpec : Specification<JournalEntryReference>
    {
        public GetJournalEntryReferenceWithJournalEntryLineKeySpec(Guid journalEntryLineId)
        {
            Guard.Against.NullOrEmpty(journalEntryLineId, nameof(journalEntryLineId));
            Query.Where(jer => jer.JournalEntryLineId == journalEntryLineId).AsNoTracking();
        }
    }
}