using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Template
{
    public class ListTemplateResponse : BaseResponse
    {
        public ListTemplateResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTemplateResponse()
        {
        }

        public List<TemplateDto> Templates { get; set; } = new();

        public int Count { get; set; }
    }
}