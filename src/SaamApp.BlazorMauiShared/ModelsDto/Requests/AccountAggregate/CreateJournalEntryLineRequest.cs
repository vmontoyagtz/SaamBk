using System;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class CreateJournalEntryLineRequest : BaseRequest
    {
        public Guid AccountId { get; set; }
        public Guid FinancialAccountingPeriodId { get; set; }
        public Guid JournalEntryId { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? Amount { get; set; }
        public Guid JournalEntryTypeRefId { get; set; }
        public string JournalEntryTypeName { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string? Notes { get; set; }
        public Guid TenantId { get; set; }
    }
}