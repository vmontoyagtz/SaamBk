using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class FinancialAccountingPeriodDto
    {
        public FinancialAccountingPeriodDto() { } // AutoMapper required

        public FinancialAccountingPeriodDto(Guid financialAccountingPeriodId, int accountingPeriod,
            DateTime periodStartDate, DateTime periodEndDate, DateTime createdAt, string? zippedStatementsUrl,
            string? zippedStatementsSharedAccessSignatureUrl, bool? isStatementsJobRunning, string? settingsJson,
            Guid tenantId)
        {
            FinancialAccountingPeriodId =
                Guard.Against.NullOrEmpty(financialAccountingPeriodId, nameof(financialAccountingPeriodId));
            AccountingPeriod = Guard.Against.NegativeOrZero(accountingPeriod, nameof(accountingPeriod));
            PeriodStartDate = Guard.Against.OutOfSQLDateRange(periodStartDate, nameof(periodStartDate));
            PeriodEndDate = Guard.Against.OutOfSQLDateRange(periodEndDate, nameof(periodEndDate));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            ZippedStatementsUrl = zippedStatementsUrl;
            ZippedStatementsSharedAccessSignatureUrl = zippedStatementsSharedAccessSignatureUrl;
            IsStatementsJobRunning = isStatementsJobRunning;
            SettingsJson = settingsJson;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid FinancialAccountingPeriodId { get; set; }

        [Required(ErrorMessage = "Accounting Period is required")]
        public int AccountingPeriod { get; set; }

        [Required(ErrorMessage = "Period Start Date is required")]
        public DateTime PeriodStartDate { get; set; }

        [Required(ErrorMessage = "Period End Date is required")]
        public DateTime PeriodEndDate { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [MaxLength(100)] public string? ZippedStatementsUrl { get; set; }

        [MaxLength(100)] public string? ZippedStatementsSharedAccessSignatureUrl { get; set; }

        public bool? IsStatementsJobRunning { get; set; }

        [MaxLength(100)] public string? SettingsJson { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<InvoiceDto> Invoices { get; set; } = new();
        public List<JournalEntryLineDto> JournalEntryLines { get; set; } = new();
    }
}