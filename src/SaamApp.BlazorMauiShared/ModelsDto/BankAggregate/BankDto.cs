using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BankDto
    {
        public BankDto() { } // AutoMapper required

        public BankDto(Guid bankId, string bankName, string? bankSwiftCodeInfo, string bankAddress,
            string bankPhoneNumber, string bankEmailAddress, string bankNotes, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            BankId = Guard.Against.NullOrEmpty(bankId, nameof(bankId));
            BankName = Guard.Against.NullOrWhiteSpace(bankName, nameof(bankName));
            BankSwiftCodeInfo = bankSwiftCodeInfo;
            BankAddress = Guard.Against.NullOrWhiteSpace(bankAddress, nameof(bankAddress));
            BankPhoneNumber = Guard.Against.NullOrWhiteSpace(bankPhoneNumber, nameof(bankPhoneNumber));
            BankEmailAddress = Guard.Against.NullOrWhiteSpace(bankEmailAddress, nameof(bankEmailAddress));
            BankNotes = Guard.Against.NullOrWhiteSpace(bankNotes, nameof(bankNotes));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid BankId { get; set; }

        [Required(ErrorMessage = "Bank Name is required")]
        [MaxLength(100)]
        public string BankName { get; set; }

        [MaxLength(100)] public string? BankSwiftCodeInfo { get; set; }

        [Required(ErrorMessage = "Bank Address is required")]
        [MaxLength(100)]
        public string BankAddress { get; set; }

        [Required(ErrorMessage = "Bank Phone Number is required")]
        [MaxLength(100)]
        public string BankPhoneNumber { get; set; }

        [Required(ErrorMessage = "Bank Email Address is required")]
        [MaxLength(100)]
        public string BankEmailAddress { get; set; }

        [Required(ErrorMessage = "Bank Note is required")]
        [MaxLength(100)]
        public string BankNotes { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<BankAccountDto> BankAccounts { get; set; } = new();
    }
}