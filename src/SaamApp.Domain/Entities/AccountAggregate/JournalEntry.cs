using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class JournalEntry : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<JournalEntryLine> _journalEntryLines = new();


        private JournalEntry() { } // EF required

        //[SetsRequiredMembers]
        public JournalEntry(Guid journalEntryId, Guid referenceId, string? referenceIdDescription,
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

        [Key] public Guid JournalEntryId { get; private set; }

        public Guid ReferenceId { get; private set; }

        public string? ReferenceIdDescription { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public Guid JournalEntryTypeId { get; private set; }

        public decimal? TotalTaxAmount { get; private set; }

        public decimal TotalAmount { get; private set; }

        public string? Description { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<JournalEntryLine> JournalEntryLines => _journalEntryLines.AsReadOnly();

        public void SetReferenceIdDescription(string referenceIdDescription)
        {
            ReferenceIdDescription = referenceIdDescription;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}