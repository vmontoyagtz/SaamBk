using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class GetByIdTemplateResponse : BaseResponse
    {
        public GetByIdTemplateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTemplateResponse()
        {
        }

        public TemplateDto Template { get; set; } = new();
    }
}