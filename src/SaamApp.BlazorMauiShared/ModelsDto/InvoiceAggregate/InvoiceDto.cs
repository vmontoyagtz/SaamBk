using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class InvoiceDto
    {
        public InvoiceDto() { } // AutoMapper required

        public InvoiceDto(Guid invoiceId, Guid accountId, Guid financialAccountingPeriodId, int invoiceNumber,
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

        public Guid InvoiceId { get; set; }

        [Required(ErrorMessage = "Invoice Number is required")]
        public int InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Account Name is required")]
        [MaxLength(100)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Payment State is required")]
        public int PaymentState { get; set; }

        [MaxLength(100)] public string? InternalComments { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? InvoicedDate { get; set; }

        [Required(ErrorMessage = "Invoicing Note is required")]
        [MaxLength(100)]
        public string InvoicingNote { get; set; }

        public decimal? TotalSale { get; set; }

        public decimal? TotalSaleTax { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public AccountDto Account { get; set; }

        [Required(ErrorMessage = "Account is required")]
        public Guid AccountId { get; set; }

        public FinancialAccountingPeriodDto FinancialAccountingPeriod { get; set; }

        [Required(ErrorMessage = "Financial Accounting Period is required")]
        public Guid FinancialAccountingPeriodId { get; set; }

        public List<InvoiceDetailDto> InvoiceDetails { get; set; } = new();
    }
}