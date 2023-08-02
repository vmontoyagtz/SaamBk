using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class JournalEntryGetListSpec : Specification<JournalEntry>
    {
        public JournalEntryGetListSpec()
        {
            Query.OrderBy(journalEntry => journalEntry.JournalEntryId)
                .AsNoTracking();
        }
    }
}