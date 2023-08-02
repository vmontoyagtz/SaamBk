using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class UpdateInvoiceRequest : BaseRequest
    {
        public Guid InvoiceId { get; set; }
        public Guid AccountId { get; set; }
        public Guid FinancialAccountingPeriodId { get; set; }
        public int InvoiceNumber { get; set; }
        public string AccountName { get; set; }
        public string CustomerName { get; set; }
        public int PaymentState { get; set; }
        public string? InternalComments { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? InvoicedDate { get; set; }
        public string InvoicingNote { get; set; }
        public decimal? TotalSale { get; set; }
        public decimal? TotalSaleTax { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateInvoiceRequest FromDto(InvoiceDto invoiceDto)
        {
            return new UpdateInvoiceRequest
            {
                InvoiceId = invoiceDto.InvoiceId,
                AccountId = invoiceDto.AccountId,
                FinancialAccountingPeriodId = invoiceDto.FinancialAccountingPeriodId,
                InvoiceNumber = invoiceDto.InvoiceNumber,
                AccountName = invoiceDto.AccountName,
                CustomerName = invoiceDto.CustomerName,
                PaymentState = invoiceDto.PaymentState,
                InternalComments = invoiceDto.InternalComments,
                CreatedAt = invoiceDto.CreatedAt,
                CreatedBy = invoiceDto.CreatedBy,
                UpdatedAt = invoiceDto.UpdatedAt,
                UpdatedBy = invoiceDto.UpdatedBy,
                InvoicedDate = invoiceDto.InvoicedDate,
                InvoicingNote = invoiceDto.InvoicingNote,
                TotalSale = invoiceDto.TotalSale,
                TotalSaleTax = invoiceDto.TotalSaleTax,
                TenantId = invoiceDto.TenantId
            };
        }
    }
}