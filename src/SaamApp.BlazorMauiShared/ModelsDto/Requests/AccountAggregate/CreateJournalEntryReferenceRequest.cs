using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryReference
{
    public class CreateJournalEntryReferenceRequest : BaseRequest
    {
        public Guid JournalEntryLineId { get; set; }
        public Guid JournalEntryTypeRefId { get; set; }
        public string JournalEntryTypeName { get; set; }
        public string? Description { get; set; }
        public Guid TenantId { get; set; }
    }
}