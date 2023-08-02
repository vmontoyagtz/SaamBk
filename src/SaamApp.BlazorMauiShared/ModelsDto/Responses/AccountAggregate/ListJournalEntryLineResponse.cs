using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class ListJournalEntryLineResponse : BaseResponse
    {
        public ListJournalEntryLineResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListJournalEntryLineResponse()
        {
        }

        public List<JournalEntryLineDto> JournalEntryLines { get; set; } = new();

        public int Count { get; set; }
    }
}