using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CategoryDto
    {
        public CategoryDto() { } // AutoMapper required

        public CategoryDto(Guid categoryId, string categoryName, string? categoryDescription, string categoryImage,
            int categoryStage, Guid tenantId)
        {
            CategoryId = Guard.Against.NullOrEmpty(categoryId, nameof(categoryId));
            CategoryName = Guard.Against.NullOrWhiteSpace(categoryName, nameof(categoryName));
            CategoryDescription = categoryDescription;
            CategoryImage = Guard.Against.NullOrWhiteSpace(categoryImage, nameof(categoryImage));
            CategoryStage = Guard.Against.NegativeOrZero(categoryStage, nameof(categoryStage));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [MaxLength(100)] public string? CategoryDescription { get; set; }

        [Required(ErrorMessage = "Category Image is required")]
        [MaxLength(100)]
        public string CategoryImage { get; set; }

        [Required(ErrorMessage = "Category Stage is required")]
        public int CategoryStage { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<RegionAreaAdvisorCategoryDto> RegionAreaAdvisorCategories { get; set; } = new();
    }
}