using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateCategory
{
    public class UpdateTemplateCategoryResponse : BaseResponse
    {
        public UpdateTemplateCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTemplateCategoryResponse()
        {
        }

        public TemplateCategoryDto TemplateCategory { get; set; } = new();
    }
}