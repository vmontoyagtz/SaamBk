using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustment
{
    public class UpdateAccountAdjustmentRequest : BaseRequest
    {
        public Guid AccountAdjustmentId { get; set; }
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

        public static UpdateAccountAdjustmentRequest FromDto(AccountAdjustmentDto accountAdjustmentDto)
        {
            return new UpdateAccountAdjustmentRequest
            {
                AccountAdjustmentId = accountAdjustmentDto.AccountAdjustmentId,
                AccountId = accountAdjustmentDto.AccountId,
                AccountAdjustmentRefId = accountAdjustmentDto.AccountAdjustmentRefId,
                AdjustmentReason = accountAdjustmentDto.AdjustmentReason,
                TotalChargeCredited = accountAdjustmentDto.TotalChargeCredited,
                TotalTaxCredited = accountAdjustmentDto.TotalTaxCredited,
                CreatedAt = accountAdjustmentDto.CreatedAt,
                CreatedBy = accountAdjustmentDto.CreatedBy,
                UpdatedAt = accountAdjustmentDto.UpdatedAt,
                UpdatedBy = accountAdjustmentDto.UpdatedBy,
                IsDeleted = accountAdjustmentDto.IsDeleted
            };
        }
    }
}