using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.JournalEntryLine
{
    public class UpdateJournalEntryLineRequest : BaseRequest
    {
        public Guid JournalEntryLineId { get; set; }
        public Guid AccountId { get; set; }
        public Guid FinancialAccountingPeriodId { get; set; }
        public Guid JournalEntryId { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? Amount { get; set; }
        public Guid JournalEntryTypeRefId { get; set; }
        public string JournalEntryTypeName { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string? Notes { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateJournalEntryLineRequest FromDto(JournalEntryLineDto journalEntryLineDto)
        {
            return new UpdateJournalEntryLineRequest
            {
                JournalEntryLineId = journalEntryLineDto.JournalEntryLineId,
                AccountId = journalEntryLineDto.AccountId,
                FinancialAccountingPeriodId = journalEntryLineDto.FinancialAccountingPeriodId,
                JournalEntryId = journalEntryLineDto.JournalEntryId,
                TaxAmount = journalEntryLineDto.TaxAmount,
                Amount = journalEntryLineDto.Amount,
                JournalEntryTypeRefId = journalEntryLineDto.JournalEntryTypeRefId,
                JournalEntryTypeName = journalEntryLineDto.JournalEntryTypeName,
                IsDebit = journalEntryLineDto.IsDebit,
                IsCredit = journalEntryLineDto.IsCredit,
                CreatedBy = journalEntryLineDto.CreatedBy,
                CreatedAt = journalEntryLineDto.CreatedAt,
                UpdatedAt = journalEntryLineDto.UpdatedAt,
                UpdatedBy = journalEntryLineDto.UpdatedBy,
                Notes = journalEntryLineDto.Notes,
                TenantId = journalEntryLineDto.TenantId
            };
        }
    }
}