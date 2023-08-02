using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class UpdateJournalEntryResponse : BaseResponse
    {
        public UpdateJournalEntryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateJournalEntryResponse()
        {
        }

        public JournalEntryDto JournalEntry { get; set; } = new();
    }
}