using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class CreateTemplateTypeRequest : BaseRequest
    {
        public string TemplateTypeName { get; set; }
        public string? TemplateTypeDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}