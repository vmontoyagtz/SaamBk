using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AppConfigParam : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AppConfigParam() { } // EF required

        //[SetsRequiredMembers]
        public AppConfigParam(Guid appConfigParamId, string appConfigParamName, string appConfigParamValue,
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

        [Key] public Guid AppConfigParamId { get; private set; }

        public string AppConfigParamName { get; private set; }

        public string AppConfigParamValue { get; private set; }

        public string AppConfigParamDescription { get; private set; }

        public decimal CustomerLowBalance { get; private set; }

        public string? AppConfigSettingsJson { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public void SetAppConfigParamName(string appConfigParamName)
        {
            AppConfigParamName = Guard.Against.NullOrEmpty(appConfigParamName, nameof(appConfigParamName));
        }

        public void SetAppConfigParamValue(string appConfigParamValue)
        {
            AppConfigParamValue = Guard.Against.NullOrEmpty(appConfigParamValue, nameof(appConfigParamValue));
        }

        public void SetAppConfigParamDescription(string appConfigParamDescription)
        {
            AppConfigParamDescription =
                Guard.Against.NullOrEmpty(appConfigParamDescription, nameof(appConfigParamDescription));
        }

        public void SetAppConfigSettingsJson(string appConfigSettingsJson)
        {
            AppConfigSettingsJson = appConfigSettingsJson;
        }
    }
}