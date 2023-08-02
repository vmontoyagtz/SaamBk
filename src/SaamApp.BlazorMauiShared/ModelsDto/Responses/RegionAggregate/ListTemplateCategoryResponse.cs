using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateCategory
{
    public class ListTemplateCategoryResponse : BaseResponse
    {
        public ListTemplateCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTemplateCategoryResponse()
        {
        }

        public List<TemplateCategoryDto> TemplateCategories { get; set; } = new();

        public int Count { get; set; }
    }
}