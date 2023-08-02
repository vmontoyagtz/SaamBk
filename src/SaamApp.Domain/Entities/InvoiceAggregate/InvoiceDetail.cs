using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class InvoiceDetail : BaseEntityEv<Guid>, IAggregateRoot
    {
        private InvoiceDetail() { } // EF required

        //[SetsRequiredMembers]
        public InvoiceDetail(Guid invoiceDetailId, Guid invoiceId, Guid productId, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, decimal quantity, string productName, decimal? unitPrice,
            decimal? lineSale, decimal? lineTax, decimal? lineDiscount)
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

        [Key] public Guid InvoiceDetailId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public decimal Quantity { get; private set; }

        public string ProductName { get; private set; }

        public decimal? UnitPrice { get; private set; }

        public decimal? LineSale { get; private set; }

        public decimal? LineTax { get; private set; }

        public decimal? LineDiscount { get; private set; }

        public virtual Invoice Invoice { get; private set; }

        public Guid InvoiceId { get; private set; }

        public virtual Product Product { get; private set; }

        public Guid ProductId { get; private set; }

        public void SetProductName(string productName)
        {
            ProductName = Guard.Against.NullOrEmpty(productName, nameof(productName));
        }

        public void UpdateInvoiceForInvoiceDetail(Guid newInvoiceId)
        {
            Guard.Against.NullOrEmpty(newInvoiceId, nameof(newInvoiceId));
            if (newInvoiceId == InvoiceId)
            {
                return;
            }

            InvoiceId = newInvoiceId;
            var invoiceDetailUpdatedEvent = new InvoiceDetailUpdatedEvent(this, "Mongo-History");
            Events.Add(invoiceDetailUpdatedEvent);
        }


        public void UpdateProductForInvoiceDetail(Guid newProductId)
        {
            Guard.Against.NullOrEmpty(newProductId, nameof(newProductId));
            if (newProductId == ProductId)
            {
                return;
            }

            ProductId = newProductId;
            var invoiceDetailUpdatedEvent = new InvoiceDetailUpdatedEvent(this, "Mongo-History");
            Events.Add(invoiceDetailUpdatedEvent);
        }
    }
}