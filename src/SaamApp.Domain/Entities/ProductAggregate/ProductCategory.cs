using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class ProductCategory : BaseEntityEv<int>, IAggregateRoot
    {
        private ProductCategory() { } // EF required

        //[SetsRequiredMembers]
        public ProductCategory(Guid comissionId, Guid productId, Guid regionAreaAdvisorCategoryId, Guid tenantId)
        {
            ComissionId = Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            ProductId = Guard.Against.NullOrEmpty(productId, nameof(productId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public int RowId { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Comission Comission { get; private set; }

        public Guid ComissionId { get; private set; }

        public virtual Product Product { get; private set; }

        public Guid ProductId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }


        public void UpdateRegionAreaAdvisorCategoryForProductCategory(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var productCategoryUpdatedEvent = new ProductCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(productCategoryUpdatedEvent);
        }


        public void UpdateComissionForProductCategory(Guid newComissionId)
        {
            Guard.Against.NullOrEmpty(newComissionId, nameof(newComissionId));
            if (newComissionId == ComissionId)
            {
                return;
            }

            ComissionId = newComissionId;
            var productCategoryUpdatedEvent = new ProductCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(productCategoryUpdatedEvent);
        }


        public void UpdateProductForProductCategory(Guid newProductId)
        {
            Guard.Against.NullOrEmpty(newProductId, nameof(newProductId));
            if (newProductId == ProductId)
            {
                return;
            }

            ProductId = newProductId;
            var productCategoryUpdatedEvent = new ProductCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(productCategoryUpdatedEvent);
        }
    }
}