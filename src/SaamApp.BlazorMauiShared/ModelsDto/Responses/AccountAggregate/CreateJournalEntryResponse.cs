using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class CreateJournalEntryResponse : BaseResponse
    {
        public CreateJournalEntryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateJournalEntryResponse()
        {
        }

        public JournalEntryDto JournalEntry { get; set; } = new();
    }
}