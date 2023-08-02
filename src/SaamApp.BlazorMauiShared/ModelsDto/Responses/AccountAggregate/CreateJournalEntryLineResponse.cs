using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class CreateJournalEntryLineResponse : BaseResponse
    {
        public CreateJournalEntryLineResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateJournalEntryLineResponse()
        {
        }

        public JournalEntryLineDto JournalEntryLine { get; set; } = new();
    }
}