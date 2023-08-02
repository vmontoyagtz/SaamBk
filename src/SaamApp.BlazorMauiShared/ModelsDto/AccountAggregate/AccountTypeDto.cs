using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AccountTypeDto
    {
        public AccountTypeDto() { } // AutoMapper required

        public AccountTypeDto(Guid accountTypeId, string accountTypeCode, string accountTypeName,
            string accountTypeDescription, Guid tenantId)
        {
            AccountTypeId = Guard.Against.NullOrEmpty(accountTypeId, nameof(accountTypeId));
            AccountTypeCode = Guard.Against.NullOrWhiteSpace(accountTypeCode, nameof(accountTypeCode));
            AccountTypeName = Guard.Against.NullOrWhiteSpace(accountTypeName, nameof(accountTypeName));
            AccountTypeDescription =
                Guard.Against.NullOrWhiteSpace(accountTypeDescription, nameof(accountTypeDescription));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AccountTypeId { get; set; }

        [Required(ErrorMessage = "Account Type Code is required")]
        [MaxLength(100)]
        public string AccountTypeCode { get; set; }

        [Required(ErrorMessage = "Account Type Name is required")]
        [MaxLength(100)]
        public string AccountTypeName { get; set; }

        [Required(ErrorMessage = "Account Type Description is required")]
        [MaxLength(100)]
        public string AccountTypeDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AccountDto> Accounts { get; set; } = new();
    }
}