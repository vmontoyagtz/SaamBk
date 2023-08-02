using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AppConfigParamDto
    {
        public AppConfigParamDto() { } // AutoMapper required

        public AppConfigParamDto(Guid appConfigParamId, string appConfigParamName, string appConfigParamValue,
            string appConfigParamDescription, decimal customerLowBalance, string? appConfigSettingsJson,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            AppConfigParamId = Guard.Against.NullOrEmpty(appConfigParamId, nameof(appConfigParamId));
            AppConfigParamName = Guard.Against.NullOrWhiteSpace(appConfigParamName, nameof(appConfigParamName));
            AppConfigParamValue = Guard.Against.NullOrWhiteSpace(appConfigParamValue, nameof(appConfigParamValue));
            AppConfigParamDescription =
                Guard.Against.NullOrWhiteSpace(appConfigParamDescription, nameof(appConfigParamDescription));
            CustomerLowBalance = Guard.Against.Negative(customerLowBalance, nameof(customerLowBalance));
            AppConfigSettingsJson = appConfigSettingsJson;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AppConfigParamId { get; set; }

        [Required(ErrorMessage = "App Config Param Name is required")]
        [MaxLength(100)]
        public string AppConfigParamName { get; set; }

        [Required(ErrorMessage = "App Config Param Value is required")]
        [MaxLength(100)]
        public string AppConfigParamValue { get; set; }

        [Required(ErrorMessage = "App Config Param Description is required")]
        [MaxLength(100)]
        public string AppConfigParamDescription { get; set; }

        [Required(ErrorMessage = "Customer Low Balance is required")]
        public decimal CustomerLowBalance { get; set; }

        [MaxLength(100)] public string? AppConfigSettingsJson { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }
    }
}