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
    public class Invoice : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<InvoiceDetail> _invoiceDetails = new();

        private Invoice() { } // EF required

        //[SetsRequiredMembers]
        public Invoice(Guid invoiceId, Guid accountId, Guid financialAccountingPeriodId, int invoiceNumber,
            string accountName, string customerName, int paymentState, string? internalComments, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, DateTime? invoicedDate, string invoicingNote,
            decimal? totalSale, decimal? totalSaleTax, Guid tenantId)
        {
            InvoiceId = Guard.Against.NullOrEmpty(invoiceId, nameof(invoiceId));
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            FinancialAccountingPeriodId =
                Guard.Against.NullOrEmpty(financialAccountingPeriodId, nameof(financialAccountingPeriodId));
            InvoiceNumber = Guard.Against.NegativeOrZero(invoiceNumber, nameof(invoiceNumber));
            AccountName = Guard.Against.NullOrWhiteSpace(accountName, nameof(accountName));
            CustomerName = Guard.Against.NullOrWhiteSpace(customerName, nameof(customerName));
            PaymentState = Guard.Against.NegativeOrZero(paymentState, nameof(paymentState));
            InternalComments = internalComments;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            InvoicedDate = invoicedDate;
            InvoicingNote = Guard.Against.NullOrWhiteSpace(invoicingNote, nameof(invoicingNote));
            TotalSale = totalSale;
            TotalSaleTax = totalSaleTax;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid InvoiceId { get; private set; }

        public int InvoiceNumber { get; private set; }

        public string AccountName { get; private set; }

        public string CustomerName { get; private set; }

        public int PaymentState { get; private set; }

        public string? InternalComments { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public DateTime? InvoicedDate { get; private set; }

        public string InvoicingNote { get; private set; }

        public decimal? TotalSale { get; private set; }

        public decimal? TotalSaleTax { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Account Account { get; private set; }

        public Guid AccountId { get; private set; }

        public virtual FinancialAccountingPeriod FinancialAccountingPeriod { get; private set; }

        public Guid FinancialAccountingPeriodId { get; private set; }
        public IEnumerable<InvoiceDetail> InvoiceDetails => _invoiceDetails.AsReadOnly();

        public void SetAccountName(string accountName)
        {
            AccountName = Guard.Against.NullOrEmpty(accountName, nameof(accountName));
        }

        public void SetCustomerName(string customerName)
        {
            CustomerName = Guard.Against.NullOrEmpty(customerName, nameof(customerName));
        }

        public void SetInternalComments(string internalComments)
        {
            InternalComments = internalComments;
        }

        public void SetInvoicingNote(string invoicingNote)
        {
            InvoicingNote = Guard.Against.NullOrEmpty(invoicingNote, nameof(invoicingNote));
        }

        public void UpdateAccountForInvoice(Guid newAccountId)
        {
            Guard.Against.NullOrEmpty(newAccountId, nameof(newAccountId));
            if (newAccountId == AccountId)
            {
                return;
            }

            AccountId = newAccountId;
            var invoiceUpdatedEvent = new InvoiceUpdatedEvent(this, "Mongo-History");
            Events.Add(invoiceUpdatedEvent);
        }


        public void UpdateFinancialAccountingPeriodForInvoice(Guid newFinancialAccountingPeriodId)
        {
            Guard.Against.NullOrEmpty(newFinancialAccountingPeriodId, nameof(newFinancialAccountingPeriodId));
            if (newFinancialAccountingPeriodId == FinancialAccountingPeriodId)
            {
                return;
            }

            FinancialAccountingPeriodId = newFinancialAccountingPeriodId;
            var invoiceUpdatedEvent = new InvoiceUpdatedEvent(this, "Mongo-History");
            Events.Add(invoiceUpdatedEvent);
        }


        public void AddNewInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            Guard.Against.Null(invoiceDetail, nameof(invoiceDetail));
            Guard.Against.NullOrEmpty(invoiceDetail.InvoiceDetailId, nameof(invoiceDetail.InvoiceDetailId));
            Guard.Against.DuplicateInvoiceDetail(_invoiceDetails, invoiceDetail, nameof(invoiceDetail));
            _invoiceDetails.Add(invoiceDetail);
            var invoiceDetailAddedEvent = new InvoiceDetailCreatedEvent(invoiceDetail, "Mongo-History");
            Events.Add(invoiceDetailAddedEvent);
        }

        public void DeleteInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            Guard.Against.Null(invoiceDetail, nameof(invoiceDetail));
            var invoiceDetailToDelete = _invoiceDetails
                .Where(id => id.InvoiceDetailId == invoiceDetail.InvoiceDetailId)
                .FirstOrDefault();
            if (invoiceDetailToDelete != null)
            {
                _invoiceDetails.Remove(invoiceDetailToDelete);
                var invoiceDetailDeletedEvent = new InvoiceDetailDeletedEvent(invoiceDetailToDelete, "Mongo-History");
                Events.Add(invoiceDetailDeletedEvent);
            }
        }
    }
}