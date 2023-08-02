using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryReference
{
    public class ListJournalEntryReferenceResponse : BaseResponse
    {
        public ListJournalEntryReferenceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListJournalEntryReferenceResponse()
        {
        }

        public List<JournalEntryReferenceDto> JournalEntryReferences { get; set; } = new();

        public int Count { get; set; }
    }
}