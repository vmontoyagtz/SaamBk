using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class UpdateTemplateTypeResponse : BaseResponse
    {
        public UpdateTemplateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTemplateTypeResponse()
        {
        }

        public TemplateTypeDto TemplateType { get; set; } = new();
    }
}