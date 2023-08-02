using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TemplateTypeDto
    {
        public TemplateTypeDto() { } // AutoMapper required

        public TemplateTypeDto(Guid templateTypeId, string templateTypeName, string? templateTypeDescription,
            Guid tenantId)
        {
            TemplateTypeId = Guard.Against.NullOrEmpty(templateTypeId, nameof(templateTypeId));
            TemplateTypeName = Guard.Against.NullOrWhiteSpace(templateTypeName, nameof(templateTypeName));
            TemplateTypeDescription = templateTypeDescription;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid TemplateTypeId { get; set; }

        [Required(ErrorMessage = "Template Type Name is required")]
        [MaxLength(100)]
        public string TemplateTypeName { get; set; }

        [MaxLength(100)] public string? TemplateTypeDescription { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<TemplateDto> Templates { get; set; } = new();
    }
}