using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateCategory
{
    public class DeleteTemplateCategoryResponse : BaseResponse
    {
        public DeleteTemplateCategoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTemplateCategoryResponse()
        {
        }
    }
}