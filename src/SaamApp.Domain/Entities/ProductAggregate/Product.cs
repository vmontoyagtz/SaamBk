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
    public class Product : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<InvoiceDetail> _invoiceDetails = new();

        private readonly List<Message> _messages = new();

        private readonly List<ProductCategory> _productCategories = new();

        private Product() { } // EF required

        //[SetsRequiredMembers]
        public Product(Guid productId, string productName, string? productDescription, decimal productUnitPrice,
            bool productIsActive, int productMinimumCharacters, int productMinimumCallMinutes,
            decimal productChargeRatePerCharacter, decimal productChargeRateCallPerSecond, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            ProductId = Guard.Against.NullOrEmpty(productId, nameof(productId));
            ProductName = Guard.Against.NullOrWhiteSpace(productName, nameof(productName));
            ProductDescription = productDescription;
            ProductUnitPrice = Guard.Against.Negative(productUnitPrice, nameof(productUnitPrice));
            ProductIsActive = Guard.Against.Null(productIsActive, nameof(productIsActive));
            ProductMinimumCharacters =
                Guard.Against.NegativeOrZero(productMinimumCharacters, nameof(productMinimumCharacters));
            ProductMinimumCallMinutes =
                Guard.Against.NegativeOrZero(productMinimumCallMinutes, nameof(productMinimumCallMinutes));
            ProductChargeRatePerCharacter =
                Guard.Against.Negative(productChargeRatePerCharacter, nameof(productChargeRatePerCharacter));
            ProductChargeRateCallPerSecond =
                Guard.Against.Negative(productChargeRateCallPerSecond, nameof(productChargeRateCallPerSecond));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public string? ProductDescription { get; private set; }

        public decimal ProductUnitPrice { get; private set; }

        public bool ProductIsActive { get; private set; }

        public int ProductMinimumCharacters { get; private set; }

        public int ProductMinimumCallMinutes { get; private set; }

        public decimal ProductChargeRatePerCharacter { get; private set; }

        public decimal ProductChargeRateCallPerSecond { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public IEnumerable<InvoiceDetail> InvoiceDetails => _invoiceDetails.AsReadOnly();
        public IEnumerable<Message> Messages => _messages.AsReadOnly();
        public IEnumerable<ProductCategory> ProductCategories => _productCategories.AsReadOnly();

        public void SetProductName(string productName)
        {
            ProductName = Guard.Against.NullOrEmpty(productName, nameof(productName));
        }

        public void SetProductDescription(string productDescription)
        {
            ProductDescription = productDescription;
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

        public void AddNewMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            Guard.Against.NullOrEmpty(message.MessageId, nameof(message.MessageId));
            Guard.Against.DuplicateMessage(_messages, message, nameof(message));
            _messages.Add(message);
            var messageAddedEvent = new MessageCreatedEvent(message, "Mongo-History");
            Events.Add(messageAddedEvent);
        }

        public void DeleteMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            var messageToDelete = _messages
                .Where(m => m.MessageId == message.MessageId)
                .FirstOrDefault();
            if (messageToDelete != null)
            {
                _messages.Remove(messageToDelete);
                var messageDeletedEvent = new MessageDeletedEvent(messageToDelete, "Mongo-History");
                Events.Add(messageDeletedEvent);
            }
        }

        public void AddNewProductCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid productId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var newProductCategory = new ProductCategory(comissionId, productId, regionAreaAdvisorCategoryId, tenantId);
            Guard.Against.DuplicateProductCategory(_productCategories, newProductCategory, nameof(newProductCategory));
            _productCategories.Add(newProductCategory);
            var productCategoryAddedEvent = new ProductCategoryCreatedEvent(newProductCategory, "Mongo-History");
            Events.Add(productCategoryAddedEvent);
        }

        public void DeleteProductCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid productId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var productCategoryToDelete = _productCategories
                .Where(pc1 => pc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(pc2 => pc2.ComissionId == comissionId)
                .Where(pc3 => pc3.ProductId == productId)
                .Where(pc4 => pc4.TenantId == tenantId)
                .FirstOrDefault();

            if (productCategoryToDelete != null)
            {
                _productCategories.Remove(productCategoryToDelete);
                var productCategoryDeletedEvent =
                    new ProductCategoryDeletedEvent(productCategoryToDelete, "Mongo-History");
                Events.Add(productCategoryDeletedEvent);
            }
        }
    }
}