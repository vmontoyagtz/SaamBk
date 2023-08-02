using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class PrepaidPackageDto
    {
        public PrepaidPackageDto() { } // AutoMapper required

        public PrepaidPackageDto(Guid prepaidPackageId, Guid regionId, string prepaidPackageName,
            decimal prepaidPackagePrice, bool? prepaidPackageIsActive, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            PrepaidPackageId = Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            PrepaidPackageName = Guard.Against.NullOrWhiteSpace(prepaidPackageName, nameof(prepaidPackageName));
            PrepaidPackagePrice = Guard.Against.Negative(prepaidPackagePrice, nameof(prepaidPackagePrice));
            PrepaidPackageIsActive = prepaidPackageIsActive;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid PrepaidPackageId { get; set; }

        [Required(ErrorMessage = "Prepaid Package Name is required")]
        [MaxLength(100)]
        public string PrepaidPackageName { get; set; }

        [Required(ErrorMessage = "Prepaid Package Price is required")]
        public decimal PrepaidPackagePrice { get; set; }

        public bool? PrepaidPackageIsActive { get; set; }

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

        public List<PrepaidPackageRedemptionDto> PrepaidPackageRedemptions { get; set; } = new();
        public List<SerfinsaPaymentDto> SerfinsaPayments { get; set; } = new();
    }
}