using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AccountDto
    {
        public AccountDto() { } // AutoMapper required

        public AccountDto(Guid accountId, Guid accountStateTypeId, Guid accountTypeId, Guid taxInformationId,
            string accountNumber, string accountName, string accountDescription, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            AccountStateTypeId = Guard.Against.NullOrEmpty(accountStateTypeId, nameof(accountStateTypeId));
            AccountTypeId = Guard.Against.NullOrEmpty(accountTypeId, nameof(accountTypeId));
            TaxInformationId = Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            AccountNumber = Guard.Against.NullOrWhiteSpace(accountNumber, nameof(accountNumber));
            AccountName = Guard.Against.NullOrWhiteSpace(accountName, nameof(accountName));
            AccountDescription = Guard.Against.NullOrWhiteSpace(accountDescription, nameof(accountDescription));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "Account Number is required")]
        [MaxLength(100)]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Account Name is required")]
        [MaxLength(100)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Account Description is required")]
        [MaxLength(100)]
        public string AccountDescription { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public AccountStateTypeDto AccountStateType { get; set; }

        [Required(ErrorMessage = "Account State Type is required")]
        public Guid AccountStateTypeId { get; set; }

        public AccountTypeDto AccountType { get; set; }

        [Required(ErrorMessage = "Account Type is required")]
        public Guid AccountTypeId { get; set; }

        public TaxInformationDto TaxInformation { get; set; }

        [Required(ErrorMessage = "Tax Information is required")]
        public Guid TaxInformationId { get; set; }

        public List<AccountAdjustmentDto> AccountAdjustments { get; set; } = new();
        public List<CustomerAccountDto> CustomerAccounts { get; set; } = new();
        public List<InvoiceDto> Invoices { get; set; } = new();
        public List<JournalEntryLineDto> JournalEntryLines { get; set; } = new();
    }
}