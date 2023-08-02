using System;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class CreateAccountAdjustmentRequest : BaseRequest
    {
        public Guid AccountId { get; set; }
        public Guid AccountAdjustmentRefId { get; set; }
        public decimal AdjustmentReason { get; set; }
        public string? TotalChargeCredited { get; set; }
        public long TotalTaxCredited { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}