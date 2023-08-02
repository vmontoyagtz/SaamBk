using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class DeleteJournalEntryRequest : BaseRequest
    {
        public Guid JournalEntryId { get; set; }
    }
}