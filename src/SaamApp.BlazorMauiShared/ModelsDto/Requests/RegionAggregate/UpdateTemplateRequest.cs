using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class UpdateTemplateRequest : BaseRequest
    {
        public Guid TemplateId { get; set; }
        public Guid TemplateTypeId { get; set; }
        public string TemplateName { get; set; }
        public string? TemplateDescription { get; set; }
        public decimal TemplateUnitPrice { get; set; }
        public bool TemplateIsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTemplateRequest FromDto(TemplateDto templateDto)
        {
            return new UpdateTemplateRequest
            {
                TemplateId = templateDto.TemplateId,
                TemplateTypeId = templateDto.TemplateTypeId,
                TemplateName = templateDto.TemplateName,
                TemplateDescription = templateDto.TemplateDescription,
                TemplateUnitPrice = templateDto.TemplateUnitPrice,
                TemplateIsActive = templateDto.TemplateIsActive,
                CreatedAt = templateDto.CreatedAt,
                CreatedBy = templateDto.CreatedBy,
                UpdatedAt = templateDto.UpdatedAt,
                UpdatedBy = templateDto.UpdatedBy,
                IsDeleted = templateDto.IsDeleted,
                TenantId = templateDto.TenantId
            };
        }
    }
}