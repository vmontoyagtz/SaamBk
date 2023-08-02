using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BankAccountDto
    {
        public BankAccountDto() { } // AutoMapper required

        public BankAccountDto(Guid bankAccountId, Guid bankId, string bankAccountName, string bankAccountNumber,
            string bankAccountNotificationPhoneNumber, string bankAccountNotificationEmailAddress, string? description,
            bool isDefault, Guid tenantId)
        {
            BankAccountId = Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            BankId = Guard.Against.NullOrEmpty(bankId, nameof(bankId));
            BankAccountName = Guard.Against.NullOrWhiteSpace(bankAccountName, nameof(bankAccountName));
            BankAccountNumber = Guard.Against.NullOrWhiteSpace(bankAccountNumber, nameof(bankAccountNumber));
            BankAccountNotificationPhoneNumber = Guard.Against.NullOrWhiteSpace(bankAccountNotificationPhoneNumber,
                nameof(bankAccountNotificationPhoneNumber));
            BankAccountNotificationEmailAddress = Guard.Against.NullOrWhiteSpace(bankAccountNotificationEmailAddress,
                nameof(bankAccountNotificationEmailAddress));
            Description = description;
            IsDefault = Guard.Against.Null(isDefault, nameof(isDefault));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid BankAccountId { get; set; }

        [Required(ErrorMessage = "Bank Account Name is required")]
        [MaxLength(100)]
        public string BankAccountName { get; set; }

        [Required(ErrorMessage = "Bank Account Number is required")]
        [MaxLength(100)]
        public string BankAccountNumber { get; set; }

        [Required(ErrorMessage = "Bank Account Notification Phone Number is required")]
        [MaxLength(100)]
        public string BankAccountNotificationPhoneNumber { get; set; }

        [Required(ErrorMessage = "Bank Account Notification Email Address is required")]
        [MaxLength(100)]
        public string BankAccountNotificationEmailAddress { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [Required(ErrorMessage = "Is Default is required")]
        public bool IsDefault { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public BankDto Bank { get; set; }

        [Required(ErrorMessage = "Bank is required")]
        public Guid BankId { get; set; }

        public List<AdvisorBankDto> AdvisorBanks { get; set; } = new();
        public List<AdvisorBankTransferInfoDto> AdvisorBankTransferInfoes { get; set; } = new();
        public List<AdvisorPaymentDto> AdvisorPayments { get; set; } = new();
    }
}