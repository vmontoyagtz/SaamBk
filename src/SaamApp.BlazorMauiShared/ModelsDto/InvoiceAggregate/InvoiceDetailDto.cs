using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class InvoiceDetailDto
    {
        public InvoiceDetailDto() { } // AutoMapper required

        public InvoiceDetailDto(Guid invoiceDetailId, Guid invoiceId, Guid productId, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, decimal quantity, string productName,
            decimal? unitPrice, decimal? lineSale, decimal? lineTax, decimal? lineDiscount)
        {
            InvoiceDetailId = Guard.Against.NullOrEmpty(invoiceDetailId, nameof(invoiceDetailId));
            InvoiceId = Guard.Against.NullOrEmpty(invoiceId, nameof(invoiceId));
            ProductId = Guard.Against.NullOrEmpty(productId, nameof(productId));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            Quantity = Guard.Against.Negative(quantity, nameof(quantity));
            ProductName = Guard.Against.NullOrWhiteSpace(productName, nameof(productName));
            UnitPrice = unitPrice;
            LineSale = lineSale;
            LineTax = lineTax;
            LineDiscount = lineDiscount;
        }

        public Guid InvoiceDetailId { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [MaxLength(100)]
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? LineSale { get; set; }

        public decimal? LineTax { get; set; }

        public decimal? LineDiscount { get; set; }

        public InvoiceDto Invoice { get; set; }

        [Required(ErrorMessage = "Invoice is required")]
        public Guid InvoiceId { get; set; }

        public ProductDto Product { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public Guid ProductId { get; set; }
    }
}