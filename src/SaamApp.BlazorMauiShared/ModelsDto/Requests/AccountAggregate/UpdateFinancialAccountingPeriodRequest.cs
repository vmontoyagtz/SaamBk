using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class UpdateFinancialAccountingPeriodRequest : BaseRequest
    {
        public Guid FinancialAccountingPeriodId { get; set; }
        public int AccountingPeriod { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ZippedStatementsUrl { get; set; }
        public string? ZippedStatementsSharedAccessSignatureUrl { get; set; }
        public bool? IsStatementsJobRunning { get; set; }
        public string? SettingsJson { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateFinancialAccountingPeriodRequest FromDto(
            FinancialAccountingPeriodDto financialAccountingPeriodDto)
        {
            return new UpdateFinancialAccountingPeriodRequest
            {
                FinancialAccountingPeriodId = financialAccountingPeriodDto.FinancialAccountingPeriodId,
                AccountingPeriod = financialAccountingPeriodDto.AccountingPeriod,
                PeriodStartDate = financialAccountingPeriodDto.PeriodStartDate,
                PeriodEndDate = financialAccountingPeriodDto.PeriodEndDate,
                CreatedAt = financialAccountingPeriodDto.CreatedAt,
                ZippedStatementsUrl = financialAccountingPeriodDto.ZippedStatementsUrl,
                ZippedStatementsSharedAccessSignatureUrl =
                    financialAccountingPeriodDto.ZippedStatementsSharedAccessSignatureUrl,
                IsStatementsJobRunning = financialAccountingPeriodDto.IsStatementsJobRunning,
                SettingsJson = financialAccountingPeriodDto.SettingsJson,
                TenantId = financialAccountingPeriodDto.TenantId
            };
        }
    }
}