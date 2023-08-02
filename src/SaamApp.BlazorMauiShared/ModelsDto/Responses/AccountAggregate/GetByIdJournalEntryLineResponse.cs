using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class GetByIdJournalEntryLineResponse : BaseResponse
    {
        public GetByIdJournalEntryLineResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdJournalEntryLineResponse()
        {
        }

        public JournalEntryLineDto JournalEntryLine { get; set; } = new();
    }
}