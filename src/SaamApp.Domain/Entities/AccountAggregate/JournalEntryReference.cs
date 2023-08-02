using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class JournalEntryReference : BaseEntityEv<int>, IAggregateRoot
    {
        private JournalEntryReference() { } // EF required

        //[SetsRequiredMembers]
        public JournalEntryReference(Guid journalEntryLineId, Guid journalEntryTypeRefId, string journalEntryTypeName,
            string? description, Guid tenantId)
        {
            JournalEntryLineId = Guard.Against.NullOrEmpty(journalEntryLineId, nameof(journalEntryLineId));
            JournalEntryTypeRefId = Guard.Against.NullOrEmpty(journalEntryTypeRefId, nameof(journalEntryTypeRefId));
            JournalEntryTypeName = Guard.Against.NullOrWhiteSpace(journalEntryTypeName, nameof(journalEntryTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public int RowId { get; private set; }

        public Guid JournalEntryTypeRefId { get; private set; }

        public string JournalEntryTypeName { get; private set; }

        public string? Description { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual JournalEntryLine JournalEntryLine { get; private set; }

        public Guid JournalEntryLineId { get; private set; }

        public void SetJournalEntryTypeName(string journalEntryTypeName)
        {
            JournalEntryTypeName = Guard.Against.NullOrEmpty(journalEntryTypeName, nameof(journalEntryTypeName));
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}