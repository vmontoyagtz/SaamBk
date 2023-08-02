using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AiAreaExpertiseDto
    {
        public AiAreaExpertiseDto() { } // AutoMapper required

        public AiAreaExpertiseDto(Guid regionAreaAdvisorCategoryId, Guid modelId, Guid tenantId)
        {
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Model Id is required")]
        public Guid ModelId { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }
    }
}