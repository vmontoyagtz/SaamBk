using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class UpdateTemplateTypeRequest : BaseRequest
    {
        public Guid TemplateTypeId { get; set; }
        public string TemplateTypeName { get; set; }
        public string? TemplateTypeDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTemplateTypeRequest FromDto(TemplateTypeDto templateTypeDto)
        {
            return new UpdateTemplateTypeRequest
            {
                TemplateTypeId = templateTypeDto.TemplateTypeId,
                TemplateTypeName = templateTypeDto.TemplateTypeName,
                TemplateTypeDescription = templateTypeDto.TemplateTypeDescription,
                TenantId = templateTypeDto.TenantId
            };
        }
    }
}