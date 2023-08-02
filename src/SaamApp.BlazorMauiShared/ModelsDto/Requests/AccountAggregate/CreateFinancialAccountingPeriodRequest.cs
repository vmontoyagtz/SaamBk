using System;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class CreateFinancialAccountingPeriodRequest : BaseRequest
    {
        public int AccountingPeriod { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ZippedStatementsUrl { get; set; }
        public string? ZippedStatementsSharedAccessSignatureUrl { get; set; }
        public bool? IsStatementsJobRunning { get; set; }
        public string? SettingsJson { get; set; }
        public Guid TenantId { get; set; }
    }
}