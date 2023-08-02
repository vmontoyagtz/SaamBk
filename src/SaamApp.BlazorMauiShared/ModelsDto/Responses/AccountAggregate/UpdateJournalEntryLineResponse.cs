using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class UpdateJournalEntryLineResponse : BaseResponse
    {
        public UpdateJournalEntryLineResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateJournalEntryLineResponse()
        {
        }

        public JournalEntryLineDto JournalEntryLine { get; set; } = new();
    }
}