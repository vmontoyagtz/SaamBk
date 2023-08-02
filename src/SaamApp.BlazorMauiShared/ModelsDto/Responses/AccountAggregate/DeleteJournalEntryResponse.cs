using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class DeleteJournalEntryResponse : BaseResponse
    {
        public DeleteJournalEntryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteJournalEntryResponse()
        {
        }
    }
}