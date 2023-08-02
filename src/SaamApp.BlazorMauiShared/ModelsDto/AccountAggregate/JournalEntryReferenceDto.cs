using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class JournalEntryReferenceDto
    {
        public JournalEntryReferenceDto() { } // AutoMapper required

        public JournalEntryReferenceDto(Guid journalEntryLineId, Guid journalEntryTypeRefId,
            string journalEntryTypeName, string? description, Guid tenantId)
        {
            JournalEntryLineId = Guard.Against.NullOrEmpty(journalEntryLineId, nameof(journalEntryLineId));
            JournalEntryTypeRefId = Guard.Against.NullOrEmpty(journalEntryTypeRefId, nameof(journalEntryTypeRefId));
            JournalEntryTypeName = Guard.Against.NullOrWhiteSpace(journalEntryTypeName, nameof(journalEntryTypeName));
            Description = description;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Journal Entry Type Ref Id is required")]
        public Guid JournalEntryTypeRefId { get; set; }

        [Required(ErrorMessage = "Journal Entry Type Name is required")]
        [MaxLength(100)]
        public string JournalEntryTypeName { get; set; }

        [MaxLength(100)] public string? Description { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public JournalEntryLineDto JournalEntryLine { get; set; }

        [Required(ErrorMessage = "Journal Entry Line is required")]
        public Guid JournalEntryLineId { get; set; }
    }
}