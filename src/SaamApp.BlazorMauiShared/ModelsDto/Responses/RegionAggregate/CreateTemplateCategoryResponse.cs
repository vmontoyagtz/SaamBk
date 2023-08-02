using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateCategory
{
    public class CreateTemplateCategoryResponse : BaseResponse
    {
        public CreateTemplateCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTemplateCategoryResponse()
        {
        }

        public TemplateCategoryDto TemplateCategory { get; set; } = new();
    }
}