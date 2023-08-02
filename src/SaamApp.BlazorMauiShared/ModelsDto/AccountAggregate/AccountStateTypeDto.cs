using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AccountStateTypeDto
    {
        public AccountStateTypeDto() { } // AutoMapper required

        public AccountStateTypeDto(Guid accountStateTypeId, string accountStateTypeCode, string accountStateTypeName,
            string? accountStateTypeDescription, Guid tenantId)
        {
            AccountStateTypeId = Guard.Against.NullOrEmpty(accountStateTypeId, nameof(accountStateTypeId));
            AccountStateTypeCode = Guard.Against.NullOrWhiteSpace(accountStateTypeCode, nameof(accountStateTypeCode));
            AccountStateTypeName = Guard.Against.NullOrWhiteSpace(accountStateTypeName, nameof(accountStateTypeName));
            AccountStateTypeDescription = accountStateTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AccountStateTypeId { get; set; }

        [Required(ErrorMessage = "Account State Type Code is required")]
        [MaxLength(100)]
        public string AccountStateTypeCode { get; set; }

        [Required(ErrorMessage = "Account State Type Name is required")]
        [MaxLength(100)]
        public string AccountStateTypeName { get; set; }

        [MaxLength(100)] public string? AccountStateTypeDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AccountDto> Accounts { get; set; } = new();
    }
}