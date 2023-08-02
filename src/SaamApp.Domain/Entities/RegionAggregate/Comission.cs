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
    public class Comission : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AiRobotCategory> _aiRobotCategories = new();

        private readonly List<ProductCategory> _productCategories = new();

        private readonly List<TemplateCategory> _templateCategories = new();

        private Comission() { } // EF required

        //[SetsRequiredMembers]
        public Comission(Guid comissionId, Guid regionAreaAdvisorCategoryId, decimal comissionPercentage,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId,
            bool isDefault)
        {
            ComissionId = Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            ComissionPercentage = Guard.Against.Negative(comissionPercentage, nameof(comissionPercentage));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            IsDefault = Guard.Against.Null(isDefault, nameof(isDefault));
        }

        [Key] public Guid ComissionId { get; private set; }

        public decimal ComissionPercentage { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public bool IsDefault { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }
        public IEnumerable<AiRobotCategory> AiRobotCategories => _aiRobotCategories.AsReadOnly();
        public IEnumerable<ProductCategory> ProductCategories => _productCategories.AsReadOnly();
        public IEnumerable<TemplateCategory> TemplateCategories => _templateCategories.AsReadOnly();


        public void UpdateRegionAreaAdvisorCategoryForComission(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var comissionUpdatedEvent = new ComissionUpdatedEvent(this, "Mongo-History");
            Events.Add(comissionUpdatedEvent);
        }


        public void AddNewAiRobotCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));

            var newAiRobotCategory = new AiRobotCategory(aiRobotId, comissionId, regionAreaAdvisorCategoryId);
            Guard.Against.DuplicateAiRobotCategory(_aiRobotCategories, newAiRobotCategory, nameof(newAiRobotCategory));
            _aiRobotCategories.Add(newAiRobotCategory);
            var aiRobotCategoryAddedEvent = new AiRobotCategoryCreatedEvent(newAiRobotCategory, "Mongo-History");
            Events.Add(aiRobotCategoryAddedEvent);
        }

        public void DeleteAiRobotCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));

            var aiRobotCategoryToDelete = _aiRobotCategories
                .Where(arc1 => arc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(arc2 => arc2.ComissionId == comissionId)
                .Where(arc3 => arc3.AiRobotId == aiRobotId)
                .FirstOrDefault();

            if (aiRobotCategoryToDelete != null)
            {
                _aiRobotCategories.Remove(aiRobotCategoryToDelete);
                var aiRobotCategoryDeletedEvent =
                    new AiRobotCategoryDeletedEvent(aiRobotCategoryToDelete, "Mongo-History");
                Events.Add(aiRobotCategoryDeletedEvent);
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

        public void AddNewTemplateCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid templateId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var newTemplateCategory =
                new TemplateCategory(comissionId, regionAreaAdvisorCategoryId, templateId, tenantId);
            Guard.Against.DuplicateTemplateCategory(_templateCategories, newTemplateCategory,
                nameof(newTemplateCategory));
            _templateCategories.Add(newTemplateCategory);
            var templateCategoryAddedEvent = new TemplateCategoryCreatedEvent(newTemplateCategory, "Mongo-History");
            Events.Add(templateCategoryAddedEvent);
        }

        public void DeleteTemplateCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid templateId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var templateCategoryToDelete = _templateCategories
                .Where(tc1 => tc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(tc2 => tc2.ComissionId == comissionId)
                .Where(tc3 => tc3.TemplateId == templateId)
                .Where(tc4 => tc4.TenantId == tenantId)
                .FirstOrDefault();

            if (templateCategoryToDelete != null)
            {
                _templateCategories.Remove(templateCategoryToDelete);
                var templateCategoryDeletedEvent =
                    new TemplateCategoryDeletedEvent(templateCategoryToDelete, "Mongo-History");
                Events.Add(templateCategoryDeletedEvent);
            }
        }
    }
}