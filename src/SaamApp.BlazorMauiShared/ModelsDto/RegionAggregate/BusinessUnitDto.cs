using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BusinessUnitDto
    {
        public BusinessUnitDto() { } // AutoMapper required

        public BusinessUnitDto(Guid businessUnitId, string businessUnitName, Guid businessAddressId,
            Guid businessPhoneNumberId, Guid businessEmailAddressId, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            BusinessUnitName = Guard.Against.NullOrWhiteSpace(businessUnitName, nameof(businessUnitName));
            BusinessAddressId = Guard.Against.NullOrEmpty(businessAddressId, nameof(businessAddressId));
            BusinessPhoneNumberId = Guard.Against.NullOrEmpty(businessPhoneNumberId, nameof(businessPhoneNumberId));
            BusinessEmailAddressId = Guard.Against.NullOrEmpty(businessEmailAddressId, nameof(businessEmailAddressId));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid BusinessUnitId { get; set; }

        [Required(ErrorMessage = "Business Unit Name is required")]
        [MaxLength(100)]
        public string BusinessUnitName { get; set; }

        [Required(ErrorMessage = "Business Address Id is required")]
        public Guid BusinessAddressId { get; set; }

        [Required(ErrorMessage = "Business Phone Number Id is required")]
        public Guid BusinessPhoneNumberId { get; set; }

        [Required(ErrorMessage = "Business Email Address Id is required")]
        public Guid BusinessEmailAddressId { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AdvisorDto> Advisors { get; set; } = new();
        public List<BusinessUnitAddressDto> BusinessUnitAddresses { get; set; } = new();
        public List<BusinessUnitCategoryDto> BusinessUnitCategories { get; set; } = new();
        public List<BusinessUnitDocumentDto> BusinessUnitDocuments { get; set; } = new();
        public List<BusinessUnitEmailAddressDto> BusinessUnitEmailAddresses { get; set; } = new();
        public List<BusinessUnitPhoneNumberDto> BusinessUnitPhoneNumbers { get; set; } = new();
        public List<TaxInformationDto> TaxInformations { get; set; } = new();
    }
}