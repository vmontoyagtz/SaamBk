using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class JournalEntryLineDto
    {
        public JournalEntryLineDto() { } // AutoMapper required

        public JournalEntryLineDto(Guid journalEntryLineId, Guid accountId, Guid financialAccountingPeriodId,
            Guid journalEntryId, decimal? taxAmount, decimal? amount, Guid journalEntryTypeRefId,
            string journalEntryTypeName, bool isDebit, bool isCredit, Guid createdBy, DateTime createdAt,
            DateTime? updatedAt, Guid? updatedBy, string? notes, Guid tenantId)
        {
            JournalEntryLineId = Guard.Against.NullOrEmpty(journalEntryLineId, nameof(journalEntryLineId));
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            FinancialAccountingPeriodId =
                Guard.Against.NullOrEmpty(financialAccountingPeriodId, nameof(financialAccountingPeriodId));
            JournalEntryId = Guard.Against.NullOrEmpty(journalEntryId, nameof(journalEntryId));
            TaxAmount = taxAmount;
            Amount = amount;
            JournalEntryTypeRefId = Guard.Against.NullOrEmpty(journalEntryTypeRefId, nameof(journalEntryTypeRefId));
            JournalEntryTypeName = Guard.Against.NullOrWhiteSpace(journalEntryTypeName, nameof(journalEntryTypeName));
            IsDebit = Guard.Against.Null(isDebit, nameof(isDebit));
            IsCredit = Guard.Against.Null(isCredit, nameof(isCredit));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            Notes = notes;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid JournalEntryLineId { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? Amount { get; set; }

        [Required(ErrorMessage = "Journal Entry Type Ref Id is required")]
        public Guid JournalEntryTypeRefId { get; set; }

        [Required(ErrorMessage = "Journal Entry Type Name is required")]
        [MaxLength(100)]
        public string JournalEntryTypeName { get; set; }

        [Required(ErrorMessage = "Is Debit is required")]
        public bool IsDebit { get; set; }

        [Required(ErrorMessage = "Is Credit is required")]
        public bool IsCredit { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        [MaxLength(100)] public string? Notes { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public AccountDto Account { get; set; }

        [Required(ErrorMessage = "Account is required")]
        public Guid AccountId { get; set; }

        public FinancialAccountingPeriodDto FinancialAccountingPeriod { get; set; }

        [Required(ErrorMessage = "Financial Accounting Period is required")]
        public Guid FinancialAccountingPeriodId { get; set; }

        public JournalEntryDto JournalEntry { get; set; }

        [Required(ErrorMessage = "Journal Entry is required")]
        public Guid JournalEntryId { get; set; }

        public List<JournalEntryReferenceDto> JournalEntryReferences { get; set; } = new();
    }
}