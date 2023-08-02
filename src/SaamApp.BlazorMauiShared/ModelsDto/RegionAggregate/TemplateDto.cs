using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TemplateDto
    {
        public TemplateDto() { } // AutoMapper required

        public TemplateDto(Guid templateId, Guid templateTypeId, string templateName, string? templateDescription,
            decimal templateUnitPrice, bool templateIsActive, DateTime createdAt, Guid createdBy, DateTime? updatedAt,
            Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            TemplateId = Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            TemplateTypeId = Guard.Against.NullOrEmpty(templateTypeId, nameof(templateTypeId));
            TemplateName = Guard.Against.NullOrWhiteSpace(templateName, nameof(templateName));
            TemplateDescription = templateDescription;
            TemplateUnitPrice = Guard.Against.Negative(templateUnitPrice, nameof(templateUnitPrice));
            TemplateIsActive = Guard.Against.Null(templateIsActive, nameof(templateIsActive));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid TemplateId { get; set; }

        [Required(ErrorMessage = "Template Name is required")]
        [MaxLength(100)]
        public string TemplateName { get; set; }

        [MaxLength(100)] public string? TemplateDescription { get; set; }

        [Required(ErrorMessage = "Template Unit Price is required")]
        public decimal TemplateUnitPrice { get; set; }

        [Required(ErrorMessage = "Template Is Active is required")]
        public bool TemplateIsActive { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public TemplateTypeDto TemplateType { get; set; }

        [Required(ErrorMessage = "Template Type is required")]
        public Guid TemplateTypeId { get; set; }

        public List<TemplateCategoryDto> TemplateCategories { get; set; } = new();
        public List<TemplateDocumentDto> TemplateDocuments { get; set; } = new();
    }
}