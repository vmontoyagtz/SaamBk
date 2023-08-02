using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AccountAdjustmentDto
    {
        public AccountAdjustmentDto() { } // AutoMapper required


        public AccountAdjustmentDto(Guid accountAdjustmentId, Guid accountId, Guid accountAdjustmentRefId,
            decimal adjustmentReason, string? totalChargeCredited, long totalTaxCredited, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted)
        {
            AccountAdjustmentId = Guard.Against.NullOrEmpty(accountAdjustmentId, nameof(accountAdjustmentId));
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            AccountAdjustmentRefId = Guard.Against.NullOrEmpty(accountAdjustmentRefId, nameof(accountAdjustmentRefId));
            AdjustmentReason = Guard.Against.Negative(adjustmentReason, nameof(adjustmentReason));
            TotalChargeCredited = totalChargeCredited;
            TotalTaxCredited = Guard.Against.NegativeOrZero(totalTaxCredited, nameof(totalTaxCredited));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
        }

        public Guid AccountAdjustmentId { get; set; }

        [Required(ErrorMessage = "Adjustment Reason is required")]
        public decimal AdjustmentReason { get; set; }

        [MaxLength(100)] public string? TotalChargeCredited { get; set; }

        [Required(ErrorMessage = "Total Tax Credited is required")]
        public long TotalTaxCredited { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public AccountDto Account { get; set; }

        [Required(ErrorMessage = "Account is required")]
        public Guid AccountId { get; set; }

        public AccountAdjustmentRefDto AccountAdjustmentRef { get; set; }

        [Required(ErrorMessage = "Account Adjustment Ref is required")]
        public Guid AccountAdjustmentRefId { get; set; }
    }
}