using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryReference
{
    public class DeleteJournalEntryReferenceResponse : BaseResponse
    {
        public DeleteJournalEntryReferenceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteJournalEntryReferenceResponse()
        {
        }
    }
}