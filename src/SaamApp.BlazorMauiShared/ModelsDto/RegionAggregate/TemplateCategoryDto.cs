using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TemplateCategoryDto
    {
        public TemplateCategoryDto() { } // AutoMapper required

        public TemplateCategoryDto(Guid comissionId, Guid regionAreaAdvisorCategoryId, Guid templateId, Guid tenantId)
        {
            ComissionId = Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            TemplateId = Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public ComissionDto Comission { get; set; }

        [Required(ErrorMessage = "Comission is required")]
        public Guid ComissionId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public TemplateDto Template { get; set; }

        [Required(ErrorMessage = "Template is required")]
        public Guid TemplateId { get; set; }
    }
}