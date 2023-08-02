using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class CreateTemplateResponse : BaseResponse
    {
        public CreateTemplateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTemplateResponse()
        {
        }

        public TemplateDto Template { get; set; } = new();
    }
}