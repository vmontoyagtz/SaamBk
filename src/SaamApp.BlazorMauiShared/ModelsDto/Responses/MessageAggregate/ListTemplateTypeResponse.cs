using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateType
{
    public class ListTemplateTypeResponse : BaseResponse
    {
        public ListTemplateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTemplateTypeResponse()
        {
        }

        public List<TemplateTypeDto> TemplateTypes { get; set; } = new();

        public int Count { get; set; }
    }
}