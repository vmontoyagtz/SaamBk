using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryReference
{
    public class CreateJournalEntryReferenceResponse : BaseResponse
    {
        public CreateJournalEntryReferenceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateJournalEntryReferenceResponse()
        {
        }

        public JournalEntryReferenceDto JournalEntryReference { get; set; } = new();
    }
}