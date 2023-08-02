using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class CreateJournalEntryRequest : BaseRequest
    {
        public Guid ReferenceId { get; set; }
        public string? ReferenceIdDescription { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid JournalEntryTypeId { get; set; }
        public decimal? TotalTaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Description { get; set; }
        public Guid TenantId { get; set; }
    }
}