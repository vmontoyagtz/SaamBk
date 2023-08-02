using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntry
{
    public class UpdateJournalEntryRequest : BaseRequest
    {
        public Guid JournalEntryId { get; set; }
        public Guid ReferenceId { get; set; }
        public string? ReferenceIdDescription { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid JournalEntryTypeId { get; set; }
        public decimal? TotalTaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Description { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateJournalEntryRequest FromDto(JournalEntryDto journalEntryDto)
        {
            return new UpdateJournalEntryRequest
            {
                JournalEntryId = journalEntryDto.JournalEntryId,
                ReferenceId = journalEntryDto.ReferenceId,
                ReferenceIdDescription = journalEntryDto.ReferenceIdDescription,
                TransactionDate = journalEntryDto.TransactionDate,
                JournalEntryTypeId = journalEntryDto.JournalEntryTypeId,
                TotalTaxAmount = journalEntryDto.TotalTaxAmount,
                TotalAmount = journalEntryDto.TotalAmount,
                Description = journalEntryDto.Description,
                TenantId = journalEntryDto.TenantId
            };
        }
    }
}