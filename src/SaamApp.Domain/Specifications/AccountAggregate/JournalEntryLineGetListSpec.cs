using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class JournalEntryLineGetListSpec : Specification<JournalEntryLine>
    {
        public JournalEntryLineGetListSpec()
        {
            Query.Where(journalEntryLine => journalEntryLine.IsDebit == true)
                .AsNoTracking();
        }
    }
}