using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class DeleteJournalEntryLineResponse : BaseResponse
    {
        public DeleteJournalEntryLineResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteJournalEntryLineResponse()
        {
        }
    }
}