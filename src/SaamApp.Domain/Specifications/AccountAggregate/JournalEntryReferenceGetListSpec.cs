using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class JournalEntryReferenceGetListSpec : Specification<JournalEntryReference>
    {
        public JournalEntryReferenceGetListSpec()
        {
            Query.OrderBy(journalEntryReference => journalEntryReference.RowId)
                .AsNoTracking();
        }
    }
}