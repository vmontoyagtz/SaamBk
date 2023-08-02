using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class GetByIdTemplateTypeResponse : BaseResponse
    {
        public GetByIdTemplateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTemplateTypeResponse()
        {
        }

        public TemplateTypeDto TemplateType { get; set; } = new();
    }
}