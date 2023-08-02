using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class GetByIdJournalEntryLineRequest : BaseRequest
    {
        public Guid JournalEntryLineId { get; set; }
    }
}