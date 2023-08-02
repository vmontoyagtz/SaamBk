using System;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class CreateInvoiceDetailRequest : BaseRequest
    {
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? LineSale { get; set; }
        public decimal? LineTax { get; set; }
        public decimal? LineDiscount { get; set; }
        public string DiscountStrategy { get; set; }
    }
}