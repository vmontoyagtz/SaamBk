using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class GetByIdJournalEntryRequest : BaseRequest
    {
        public Guid JournalEntryId { get; set; }
    }
}