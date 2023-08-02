using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class ListJournalEntryResponse : BaseResponse
    {
        public ListJournalEntryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListJournalEntryResponse()
        {
        }

        public List<JournalEntryDto> JournalEntries { get; set; } = new();

        public int Count { get; set; }
    }
}