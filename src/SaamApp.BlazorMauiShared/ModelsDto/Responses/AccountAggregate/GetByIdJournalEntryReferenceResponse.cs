using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryReference
{
    public class GetByIdJournalEntryReferenceResponse : BaseResponse
    {
        public GetByIdJournalEntryReferenceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdJournalEntryReferenceResponse()
        {
        }

        public JournalEntryReferenceDto JournalEntryReference { get; set; } = new();
    }
}