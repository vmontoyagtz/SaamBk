using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class ComissionDto
    {
        public ComissionDto() { } // AutoMapper required

        public ComissionDto(Guid comissionId, Guid regionAreaAdvisorCategoryId, decimal comissionPercentage,
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

        public Guid ComissionId { get; set; }

        [Required(ErrorMessage = "Comission Percentage is required")]
        public decimal ComissionPercentage { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        [Required(ErrorMessage = "Is Default is required")]
        public bool IsDefault { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public List<AiRobotCategoryDto> AiRobotCategories { get; set; } = new();
        public List<ProductCategoryDto> ProductCategories { get; set; } = new();
        public List<TemplateCategoryDto> TemplateCategories { get; set; } = new();
    }
}