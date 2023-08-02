using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class ProductCategoryDto
    {
        public ProductCategoryDto() { } // AutoMapper required

        public ProductCategoryDto(Guid comissionId, Guid productId, Guid regionAreaAdvisorCategoryId, Guid tenantId)
        {
            ComissionId = Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            ProductId = Guard.Against.NullOrEmpty(productId, nameof(productId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public ComissionDto Comission { get; set; }

        [Required(ErrorMessage = "Comission is required")]
        public Guid ComissionId { get; set; }

        public ProductDto Product { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public Guid ProductId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}