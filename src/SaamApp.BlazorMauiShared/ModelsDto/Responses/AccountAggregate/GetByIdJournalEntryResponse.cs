using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class GetByIdJournalEntryResponse : BaseResponse
    {
        public GetByIdJournalEntryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdJournalEntryResponse()
        {
        }

        public JournalEntryDto JournalEntry { get; set; } = new();
    }
}