using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TemplateCategory
{
    public class GetByIdTemplateCategoryResponse : BaseResponse
    {
        public GetByIdTemplateCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTemplateCategoryResponse()
        {
        }

        public TemplateCategoryDto TemplateCategory { get; set; } = new();
    }
}