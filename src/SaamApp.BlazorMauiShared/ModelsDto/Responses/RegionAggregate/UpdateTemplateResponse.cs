using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class UpdateTemplateResponse : BaseResponse
    {
        public UpdateTemplateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTemplateResponse()
        {
        }

        public TemplateDto Template { get; set; } = new();
    }
}