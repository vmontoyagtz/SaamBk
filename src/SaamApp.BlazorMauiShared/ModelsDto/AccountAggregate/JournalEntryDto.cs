using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class JournalEntryDto
    {
        public JournalEntryDto() { } // AutoMapper required

        public JournalEntryDto(Guid journalEntryId, Guid referenceId, string? referenceIdDescription,
            DateTime transactionDate, Guid journalEntryTypeId, decimal? totalTaxAmount, decimal totalAmount,
            string? description, Guid tenantId)
        {
            JournalEntryId = Guard.Against.NullOrEmpty(journalEntryId, nameof(journalEntryId));
            ReferenceId = Guard.Against.NullOrEmpty(referenceId, nameof(referenceId));
            ReferenceIdDescription = referenceIdDescription;
            TransactionDate = Guard.Against.OutOfSQLDateRange(transactionDate, nameof(transactionDate));
            JournalEntryTypeId = Guard.Against.NullOrEmpty(journalEntryTypeId, nameof(journalEntryTypeId));
            TotalTaxAmount = totalTaxAmount;
            TotalAmount = Guard.Against.Negative(totalAmount, nameof(totalAmount));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid JournalEntryId { get; set; }

        [Required(ErrorMessage = "Reference Id is required")]
        public Guid ReferenceId { get; set; }

        [MaxLength(100)] public string? ReferenceIdDescription { get; set; }

        [Required(ErrorMessage = "Transaction Date is required")]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Journal Entry Type Id is required")]
        public Guid JournalEntryTypeId { get; set; }

        public decimal? TotalTaxAmount { get; set; }

        [Required(ErrorMessage = "Total Amount is required")]
        public decimal TotalAmount { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<JournalEntryLineDto> JournalEntryLines { get; set; } = new();
    }
}