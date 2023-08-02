using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class CreateTemplateTypeResponse : BaseResponse
    {
        public CreateTemplateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTemplateTypeResponse()
        {
        }

        public TemplateTypeDto TemplateType { get; set; } = new();
    }
}