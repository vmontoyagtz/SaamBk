using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class DiscountCodeDto
    {
        public DiscountCodeDto() { } // AutoMapper required

        public DiscountCodeDto(Guid discountCodeId, Guid regionId, string discountCodeName, string discountCodeValue,
            decimal discountCodePercentage, DateTime discountCodeStartDate, DateTime? discountCodeEndDate,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            DiscountCodeId = Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            DiscountCodeName = Guard.Against.NullOrWhiteSpace(discountCodeName, nameof(discountCodeName));
            DiscountCodeValue = Guard.Against.NullOrWhiteSpace(discountCodeValue, nameof(discountCodeValue));
            DiscountCodePercentage = Guard.Against.Negative(discountCodePercentage, nameof(discountCodePercentage));
            DiscountCodeStartDate =
                Guard.Against.OutOfSQLDateRange(discountCodeStartDate, nameof(discountCodeStartDate));
            DiscountCodeEndDate = discountCodeEndDate;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid DiscountCodeId { get; set; }

        [Required(ErrorMessage = "Discount Code Name is required")]
        [MaxLength(100)]
        public string DiscountCodeName { get; set; }

        [Required(ErrorMessage = "Discount Code Value is required")]
        [MaxLength(100)]
        public string DiscountCodeValue { get; set; }

        [Required(ErrorMessage = "Discount Code Percentage is required")]
        public decimal DiscountCodePercentage { get; set; }

        [Required(ErrorMessage = "Discount Code Start Date is required")]
        public DateTime DiscountCodeStartDate { get; set; }

        public DateTime? DiscountCodeEndDate { get; set; }

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

        public List<DiscountCodeRedemptionDto> DiscountCodeRedemptions { get; set; } = new();
        public List<SerfinsaPaymentDto> SerfinsaPayments { get; set; } = new();
    }
}