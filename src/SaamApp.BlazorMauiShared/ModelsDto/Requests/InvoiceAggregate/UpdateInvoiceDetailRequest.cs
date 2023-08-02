using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class UpdateInvoiceDetailRequest : BaseRequest
    {
        public Guid InvoiceDetailId { get; set; }
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

        public static UpdateInvoiceDetailRequest FromDto(InvoiceDetailDto invoiceDetailDto)
        {
            return new UpdateInvoiceDetailRequest
            {
                InvoiceDetailId = invoiceDetailDto.InvoiceDetailId,
                InvoiceId = invoiceDetailDto.InvoiceId,
                ProductId = invoiceDetailDto.ProductId,
                CreatedAt = invoiceDetailDto.CreatedAt,
                CreatedBy = invoiceDetailDto.CreatedBy,
                UpdatedAt = invoiceDetailDto.UpdatedAt,
                UpdatedBy = invoiceDetailDto.UpdatedBy,
                Quantity = invoiceDetailDto.Quantity,
                ProductName = invoiceDetailDto.ProductName,
                UnitPrice = invoiceDetailDto.UnitPrice,
                LineSale = invoiceDetailDto.LineSale,
                LineTax = invoiceDetailDto.LineTax,
                LineDiscount = invoiceDetailDto.LineDiscount
            };
        }
    }
}