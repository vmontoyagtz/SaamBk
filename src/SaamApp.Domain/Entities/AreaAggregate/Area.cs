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
    public class Area : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<RegionAreaAdvisorCategory> _regionAreaAdvisorCategories = new();

        private Area() { } // EF required

        //[SetsRequiredMembers]
        public Area(Guid areaId, string areaName, string areaDescription, string areaColor, string areaImage,
            bool areaStage, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted,
            Guid tenantId)
        {
            AreaId = Guard.Against.NullOrEmpty(areaId, nameof(areaId));
            AreaName = Guard.Against.NullOrWhiteSpace(areaName, nameof(areaName));
            AreaDescription = Guard.Against.NullOrWhiteSpace(areaDescription, nameof(areaDescription));
            AreaColor = Guard.Against.NullOrWhiteSpace(areaColor, nameof(areaColor));
            AreaImage = Guard.Against.NullOrWhiteSpace(areaImage, nameof(areaImage));
            AreaStage = Guard.Against.Null(areaStage, nameof(areaStage));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid AreaId { get; private set; }

        public string AreaName { get; private set; }

        public string AreaDescription { get; private set; }

        public string AreaColor { get; private set; }

        public string AreaImage { get; private set; }

        public bool AreaStage { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public IEnumerable<RegionAreaAdvisorCategory> RegionAreaAdvisorCategories =>
            _regionAreaAdvisorCategories.AsReadOnly();

        public void SetAreaName(string areaName)
        {
            AreaName = Guard.Against.NullOrEmpty(areaName, nameof(areaName));
        }

        public void SetAreaDescription(string areaDescription)
        {
            AreaDescription = Guard.Against.NullOrEmpty(areaDescription, nameof(areaDescription));
        }

        public void SetAreaColor(string areaColor)
        {
            AreaColor = Guard.Against.NullOrEmpty(areaColor, nameof(areaColor));
        }

        public void SetAreaImage(string areaImage)
        {
            AreaImage = Guard.Against.NullOrEmpty(areaImage, nameof(areaImage));
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