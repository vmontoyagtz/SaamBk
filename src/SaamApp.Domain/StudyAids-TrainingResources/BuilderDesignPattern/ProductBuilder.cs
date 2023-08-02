using System;

namespace SaamApp.Domain.TeachingMaterial.BuilderDesignPattern
{
    public class ProductBuilder
    {
        private Guid ProductId { get; set; }
        private string Name { get; set; }
        public string? Sku { get; set; }
        public int? ProductNumber { get; set; }
        public string? ProductInternalCode { get; set; }
        private string? Description { get; set; }
        private decimal? Stock { get; set; }
        private decimal? Price { get; set; }
        private bool IsActive { get; set; }
        private bool IsDeleted { get; set; }
        public Guid TenantId { get; set; }
        private Guid ProductTypeId { get; set; }

        public ProductBuilder WithProductId(Guid productId)
        {
            ProductId = productId;
            return this;
        }

        public ProductBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ProductBuilder WithProductNumber(int? productNumber)
        {
            ProductNumber = productNumber;
            return this;
        }

        public ProductBuilder WithProductInternalCode(string? productInternalCode)
        {
            ProductInternalCode = productInternalCode;
            return this;
        }

        public ProductBuilder WithSku(string? sku)
        {
            Sku = sku;
            return this;
        }

        public ProductBuilder WithTenantId(Guid tenantId)
        {
            TenantId = tenantId;
            return this;
        }

        public ProductBuilder WithDescription(string? description)
        {
            Description = description;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public ProductBuilder WithStock(int stock)
        {
            Stock = stock;
            return this;
        }

        public ProductBuilder WithIsActive(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public ProductBuilder WithIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
            return this;
        }

        public ProductBuilder WithProductTypeId(Guid productTypeId)
        {
            ProductTypeId = productTypeId;
            return this;
        }
    }
}