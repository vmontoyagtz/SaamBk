using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TaxInformationDto
    {
        public TaxInformationDto() { } // AutoMapper required

        public TaxInformationDto(Guid taxInformationId, Guid businessUnitId, Guid taxpayerTypeId, Guid businessTypeId,
            string? taxInformationBusinessName, string? taxInformationCommercialName, Guid taxInformationRegistrationId,
            string? taxInformationBusinessIndustry, DateTime createdAt, Guid createdBy, DateTime? updatedAt,
            Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            TaxInformationId = Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            TaxpayerTypeId = Guard.Against.NullOrEmpty(taxpayerTypeId, nameof(taxpayerTypeId));
            BusinessTypeId = Guard.Against.NullOrEmpty(businessTypeId, nameof(businessTypeId));
            TaxInformationBusinessName = taxInformationBusinessName;
            TaxInformationCommercialName = taxInformationCommercialName;
            TaxInformationRegistrationId =
                Guard.Against.NullOrEmpty(taxInformationRegistrationId, nameof(taxInformationRegistrationId));
            TaxInformationBusinessIndustry = taxInformationBusinessIndustry;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid TaxInformationId { get; set; }

        [Required(ErrorMessage = "Business Type Id is required")]
        public Guid BusinessTypeId { get; set; }

        [MaxLength(100)] public string? TaxInformationBusinessName { get; set; }

        [MaxLength(100)] public string? TaxInformationCommercialName { get; set; }

        [Required(ErrorMessage = "Tax Information Registration Id is required")]
        public Guid TaxInformationRegistrationId { get; set; }

        [MaxLength(100)] public string? TaxInformationBusinessIndustry { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public BusinessUnitDto BusinessUnit { get; set; }

        [Required(ErrorMessage = "Business Unit is required")]
        public Guid BusinessUnitId { get; set; }

        public TaxpayerTypeDto TaxpayerType { get; set; }

        [Required(ErrorMessage = "Taxpayer Type is required")]
        public Guid TaxpayerTypeId { get; set; }

        public List<AccountDto> Accounts { get; set; } = new();
        public List<AdvisorDto> Advisors { get; set; } = new();
    }
}