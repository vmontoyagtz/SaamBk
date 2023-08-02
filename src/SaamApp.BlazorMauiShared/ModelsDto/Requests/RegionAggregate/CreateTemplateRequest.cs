using System;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class CreateTemplateRequest : BaseRequest
    {
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
    }
}