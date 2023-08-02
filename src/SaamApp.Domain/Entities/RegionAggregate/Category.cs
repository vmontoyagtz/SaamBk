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
    public class Category : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<RegionAreaAdvisorCategory> _regionAreaAdvisorCategories = new();

        private Category() { } // EF required

        //[SetsRequiredMembers]
        public Category(Guid categoryId, string categoryName, string? categoryDescription, string categoryImage,
            int categoryStage, Guid tenantId)
        {
            CategoryId = Guard.Against.NullOrEmpty(categoryId, nameof(categoryId));
            CategoryName = Guard.Against.NullOrWhiteSpace(categoryName, nameof(categoryName));
            CategoryDescription = categoryDescription;
            CategoryImage = Guard.Against.NullOrWhiteSpace(categoryImage, nameof(categoryImage));
            CategoryStage = Guard.Against.NegativeOrZero(categoryStage, nameof(categoryStage));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid CategoryId { get; private set; }

        public string CategoryName { get; private set; }

        public string? CategoryDescription { get; private set; }

        public string CategoryImage { get; private set; }

        public int CategoryStage { get; private set; }

        public Guid TenantId { get; private set; }

        public IEnumerable<RegionAreaAdvisorCategory> RegionAreaAdvisorCategories =>
            _regionAreaAdvisorCategories.AsReadOnly();

        public void SetCategoryName(string categoryName)
        {
            CategoryName = Guard.Against.NullOrEmpty(categoryName, nameof(categoryName));
        }

        public void SetCategoryDescription(string categoryDescription)
        {
            CategoryDescription = categoryDescription;
        }

        public void SetCategoryImage(string categoryImage)
        {
            CategoryImage = Guard.Against.NullOrEmpty(categoryImage, nameof(categoryImage));
        }


        public void AddNewRegionAreaAdvisorCategory(RegionAreaAdvisorCategory regionAreaAdvisorCategory)
        {
            Guard.Against.Null(regionAreaAdvisorCategory, nameof(regionAreaAdvisorCategory));
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId,
                nameof(regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId));
            Guard.Against.DuplicateRegionAreaAdvisorCategory(_regionAreaAdvisorCategories, regionAreaAdvisorCategory,
                nameof(regionAreaAdvisorCategory));
            _regionAreaAdvisorCategories.Add(regionAreaAdvisorCategory);
            var regionAreaAdvisorCategoryAddedEvent =
                new RegionAreaAdvisorCategoryCreatedEvent(regionAreaAdvisorCategory, "Mongo-History");
            Events.Add(regionAreaAdvisorCategoryAddedEvent);
        }

        public void DeleteRegionAreaAdvisorCategory(RegionAreaAdvisorCategory regionAreaAdvisorCategory)
        {
            Guard.Against.Null(regionAreaAdvisorCategory, nameof(regionAreaAdvisorCategory));
            var regionAreaAdvisorCategoryToDelete = _regionAreaAdvisorCategories
                .Where(raac =>
                    raac.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId)
                .FirstOrDefault();
            if (regionAreaAdvisorCategoryToDelete != null)
            {
                _regionAreaAdvisorCategories.Remove(regionAreaAdvisorCategoryToDelete);
                var regionAreaAdvisorCategoryDeletedEvent =
                    new RegionAreaAdvisorCategoryDeletedEvent(regionAreaAdvisorCategoryToDelete, "Mongo-History");
                Events.Add(regionAreaAdvisorCategoryDeletedEvent);
            }
        }
    }
}