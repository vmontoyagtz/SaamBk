using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AreaDto
    {
        public AreaDto() { } // AutoMapper required

        public AreaDto(Guid areaId, string areaName, string areaDescription, string areaColor, string areaImage,
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

        public Guid AreaId { get; set; }

        [Required(ErrorMessage = "Area Name is required")]
        [MaxLength(100)]
        public string AreaName { get; set; }

        [Required(ErrorMessage = "Area Description is required")]
        [MaxLength(100)]
        public string AreaDescription { get; set; }

        [Required(ErrorMessage = "Area Color is required")]
        [MaxLength(100)]
        public string AreaColor { get; set; }

        [Required(ErrorMessage = "Area Image is required")]
        [MaxLength(100)]
        public string AreaImage { get; set; }

        [Required(ErrorMessage = "Area Stage is required")]
        public bool AreaStage { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<RegionAreaAdvisorCategoryDto> RegionAreaAdvisorCategories { get; set; } = new();
    }
}