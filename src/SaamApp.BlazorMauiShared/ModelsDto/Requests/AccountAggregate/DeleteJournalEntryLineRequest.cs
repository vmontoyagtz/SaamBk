using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class DeleteJournalEntryLineRequest : BaseRequest
    {
        public Guid JournalEntryLineId { get; set; }
    }
}