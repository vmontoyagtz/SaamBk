using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AccountAdjustmentRefDto
    {
        public AccountAdjustmentRefDto() { } // AutoMapper required

        public AccountAdjustmentRefDto(Guid accountAdjustmentRefId, string accountAdjustmentRefName,
            string accountAdjustmentRefDescription, Guid tenantId)
        {
            AccountAdjustmentRefId = Guard.Against.NullOrEmpty(accountAdjustmentRefId, nameof(accountAdjustmentRefId));
            AccountAdjustmentRefName =
                Guard.Against.NullOrWhiteSpace(accountAdjustmentRefName, nameof(accountAdjustmentRefName));
            AccountAdjustmentRefDescription = Guard.Against.NullOrWhiteSpace(accountAdjustmentRefDescription,
                nameof(accountAdjustmentRefDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AccountAdjustmentRefId { get; set; }

        [Required(ErrorMessage = "Account Adjustment Ref Name is required")]
        [MaxLength(100)]
        public string AccountAdjustmentRefName { get; set; }

        [Required(ErrorMessage = "Account Adjustment Ref Description is required")]
        [MaxLength(100)]
        public string AccountAdjustmentRefDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AccountAdjustmentDto> AccountAdjustments { get; set; } = new();
    }
}