using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class FinancialAccountingPeriod : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Invoice> _invoices = new();

        private readonly List<JournalEntryLine> _journalEntryLines = new();

        private FinancialAccountingPeriod() { } // EF required

        //[SetsRequiredMembers]
        public FinancialAccountingPeriod(Guid financialAccountingPeriodId, int accountingPeriod,
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

        [Key] public Guid FinancialAccountingPeriodId { get; private set; }

        public int AccountingPeriod { get; private set; }

        public DateTime PeriodStartDate { get; private set; }

        public DateTime PeriodEndDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string? ZippedStatementsUrl { get; private set; }

        public string? ZippedStatementsSharedAccessSignatureUrl { get; private set; }

        public bool? IsStatementsJobRunning { get; private set; }

        public string? SettingsJson { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<Invoice> Invoices => _invoices.AsReadOnly();
        public IEnumerable<JournalEntryLine> JournalEntryLines => _journalEntryLines.AsReadOnly();

        public void SetZippedStatementsUrl(string zippedStatementsUrl)
        {
            ZippedStatementsUrl = zippedStatementsUrl;
        }

        public void SetZippedStatementsSharedAccessSignatureUrl(string zippedStatementsSharedAccessSignatureUrl)
        {
            ZippedStatementsSharedAccessSignatureUrl = zippedStatementsSharedAccessSignatureUrl;
        }

        public void SetSettingsJson(string settingsJson)
        {
            SettingsJson = settingsJson;
        }


        public void AddNewInvoice(Invoice invoice)
        {
            Guard.Against.Null(invoice, nameof(invoice));
            Guard.Against.NullOrEmpty(invoice.InvoiceId, nameof(invoice.InvoiceId));
            Guard.Against.DuplicateInvoice(_invoices, invoice, nameof(invoice));
            _invoices.Add(invoice);
            var invoiceAddedEvent = new InvoiceCreatedEvent(invoice, "Mongo-History");
            Events.Add(invoiceAddedEvent);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            Guard.Against.Null(invoice, nameof(invoice));
            var invoiceToDelete = _invoices
                .Where(i => i.InvoiceId == invoice.InvoiceId)
                .FirstOrDefault();
            if (invoiceToDelete != null)
            {
                _invoices.Remove(invoiceToDelete);
                var invoiceDeletedEvent = new InvoiceDeletedEvent(invoiceToDelete, "Mongo-History");
                Events.Add(invoiceDeletedEvent);
            }
        }

        public void AddNewJournalEntryLine(JournalEntryLine journalEntryLine)
        {
            Guard.Against.Null(journalEntryLine, nameof(journalEntryLine));
            Guard.Against.NullOrEmpty(journalEntryLine.JournalEntryLineId, nameof(journalEntryLine.JournalEntryLineId));
            Guard.Against.DuplicateJournalEntryLine(_journalEntryLines, journalEntryLine, nameof(journalEntryLine));
            _journalEntryLines.Add(journalEntryLine);
            var journalEntryLineAddedEvent = new JournalEntryLineCreatedEvent(journalEntryLine, "Mongo-History");
            Events.Add(journalEntryLineAddedEvent);
        }

        public void DeleteJournalEntryLine(JournalEntryLine journalEntryLine)
        {
            Guard.Against.Null(journalEntryLine, nameof(journalEntryLine));
            var journalEntryLineToDelete = _journalEntryLines
                .Where(jel => jel.JournalEntryLineId == journalEntryLine.JournalEntryLineId)
                .FirstOrDefault();
            if (journalEntryLineToDelete != null)
            {
                _journalEntryLines.Remove(journalEntryLineToDelete);
                var journalEntryLineDeletedEvent =
                    new JournalEntryLineDeletedEvent(journalEntryLineToDelete, "Mongo-History");
                Events.Add(journalEntryLineDeletedEvent);
            }
        }
    }
}