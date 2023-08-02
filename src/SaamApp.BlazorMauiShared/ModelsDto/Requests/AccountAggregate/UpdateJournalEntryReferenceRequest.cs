using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryReference
{
    public class UpdateJournalEntryReferenceRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid JournalEntryLineId { get; set; }
        public Guid JournalEntryTypeRefId { get; set; }
        public string JournalEntryTypeName { get; set; }
        public string? Description { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateJournalEntryReferenceRequest FromDto(JournalEntryReferenceDto journalEntryReferenceDto)
        {
            return new UpdateJournalEntryReferenceRequest
            {
                RowId = journalEntryReferenceDto.RowId,
                JournalEntryLineId = journalEntryReferenceDto.JournalEntryLineId,
                JournalEntryTypeRefId = journalEntryReferenceDto.JournalEntryTypeRefId,
                JournalEntryTypeName = journalEntryReferenceDto.JournalEntryTypeName,
                Description = journalEntryReferenceDto.Description,
                TenantId = journalEntryReferenceDto.TenantId
            };
        }
    }
}