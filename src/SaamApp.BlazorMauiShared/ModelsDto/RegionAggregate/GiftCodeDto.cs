using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class GiftCodeDto
    {
        public GiftCodeDto() { } // AutoMapper required

        public GiftCodeDto(Guid giftCodeId, Guid regionId, string? giftCodeName, string giftCodeValue,
            decimal giftCodeAmount, DateTime giftCodeStartDate, DateTime? giftCodeEndDate, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            GiftCodeId = Guard.Against.NullOrEmpty(giftCodeId, nameof(giftCodeId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            GiftCodeName = giftCodeName;
            GiftCodeValue = Guard.Against.NullOrWhiteSpace(giftCodeValue, nameof(giftCodeValue));
            GiftCodeAmount = Guard.Against.Negative(giftCodeAmount, nameof(giftCodeAmount));
            GiftCodeStartDate = Guard.Against.OutOfSQLDateRange(giftCodeStartDate, nameof(giftCodeStartDate));
            GiftCodeEndDate = giftCodeEndDate;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid GiftCodeId { get; set; }

        [MaxLength(100)] public string? GiftCodeName { get; set; }

        [Required(ErrorMessage = "Gift Code Value is required")]
        [MaxLength(100)]
        public string GiftCodeValue { get; set; }

        [Required(ErrorMessage = "Gift Code Amount is required")]
        public decimal GiftCodeAmount { get; set; }

        [Required(ErrorMessage = "Gift Code Start Date is required")]
        public DateTime GiftCodeStartDate { get; set; }

        public DateTime? GiftCodeEndDate { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public RegionDto Region { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public Guid RegionId { get; set; }

        public List<GiftCodeRedemptionDto> GiftCodeRedemptions { get; set; } = new();
    }
}