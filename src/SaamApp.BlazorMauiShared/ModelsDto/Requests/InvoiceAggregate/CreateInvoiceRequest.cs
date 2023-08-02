using System;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class CreateInvoiceRequest : BaseRequest
    {
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
    }
}