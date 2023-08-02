using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class JournalEntryLine : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<JournalEntryReference> _journalEntryReferences = new();


        private JournalEntryLine() { } // EF required

        //[SetsRequiredMembers]
        public JournalEntryLine(Guid journalEntryLineId, Guid accountId, Guid financialAccountingPeriodId,
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

        [Key] public Guid JournalEntryLineId { get; private set; }

        public decimal? TaxAmount { get; private set; }

        public decimal? Amount { get; private set; }

        public Guid JournalEntryTypeRefId { get; private set; }

        public string JournalEntryTypeName { get; private set; }

        public bool IsDebit { get; private set; }

        public bool IsCredit { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public string? Notes { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Account Account { get; private set; }

        public Guid AccountId { get; private set; }

        public virtual FinancialAccountingPeriod FinancialAccountingPeriod { get; private set; }

        public Guid FinancialAccountingPeriodId { get; private set; }

        public virtual JournalEntry JournalEntry { get; private set; }

        public Guid JournalEntryId { get; private set; }
        public IEnumerable<JournalEntryReference> JournalEntryReferences => _journalEntryReferences.AsReadOnly();

        public void SetJournalEntryTypeName(string journalEntryTypeName)
        {
            JournalEntryTypeName = Guard.Against.NullOrEmpty(journalEntryTypeName, nameof(journalEntryTypeName));
        }

        public void SetNotes(string notes)
        {
            Notes = notes;
        }
    }
}