using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryReference
{
    public class UpdateJournalEntryReferenceResponse : BaseResponse
    {
        public UpdateJournalEntryReferenceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateJournalEntryReferenceResponse()
        {
        }

        public JournalEntryReferenceDto JournalEntryReference { get; set; } = new();
    }
}